﻿using Faith.Application.Contracts.Application.Dto.ExceptionDto;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.Redis
{
    public class RedisClient : IRedisClient
    {
        public volatile ConnectionMultiplexer _redisConnection;
        private readonly object _redisConnectionLock = new object();
        private readonly ConfigurationOptions _configOptions;
        private IOptions<RedisConfig> _settings;
        private readonly ILogger<RedisClient> _logger;
        public RedisClient(ILogger<RedisClient> _logger, IOptions<RedisConfig> settings)
        {
            this._settings = settings;
            this._logger = _logger;
            ConfigurationOptions options = ReadRedisSetting();
            if (options == null)
            {
                _logger.LogError("Redis数据库配置有误");
            }
            this._configOptions = options;
            this._redisConnection = ConnectionRedis();
        }
        private ConfigurationOptions ReadRedisSetting()
        {
            try
            {
                ConfigurationOptions options = new ConfigurationOptions
                    {
                        EndPoints =
                            {
                                {
                                    _settings.Value.Ip,
                                    int.Parse(_settings.Value.Port)
                                }
                            },
                        ClientName = _settings.Value.Name,
                        Password = _settings.Value.Password,
                        ConnectTimeout = int.Parse(_settings.Value.Timeout),
                        DefaultDatabase = int.Parse(_settings.Value.Db),
                        AbortOnConnectFail = false
                    };
                    return options;
            }
            catch (Exception ex)
            {
                _logger.LogError($"获取Redis配置信息失败：{ex.Message}");
                throw new UserFriendlyException(404, "服务繁忙！");
            }

        }
        private ConnectionMultiplexer ConnectionRedis()
        {
            if (this._redisConnection != null && this._redisConnection.IsConnected)
            {
                return this._redisConnection; // 已有连接，直接使用
            }
            lock (_redisConnectionLock)
            {
                if (this._redisConnection != null)
                {
                    this._redisConnection.Dispose(); // 释放，重连
                }
                try
                {
                    this._redisConnection = ConnectionMultiplexer.Connect(_configOptions);
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Redis服务启动失败：{ex.Message}");
                }
            }
            return this._redisConnection;
        }
        public string GetValue(string key)
        {
            return _redisConnection.GetDatabase().StringGet(key);
        }

        public void Set(string key, object value, TimeSpan ts)
        {
            if (value != null)
            {
                _redisConnection.GetDatabase().StringSet(key, JsonConvert.SerializeObject(value), ts);
            }
        }

        public void Clear()
        {
            foreach (var endPoint in this.ConnectionRedis().GetEndPoints())
            {
                var server = this.ConnectionRedis().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    _redisConnection.GetDatabase().KeyDelete(key);
                }
            }
        }

        public bool Get(string key)
        {
            return _redisConnection.GetDatabase().KeyExists(key);
        }


        public TEntity Get<TEntity>(string key)
        {
            var value = _redisConnection.GetDatabase().StringGet(key);
            if (value.HasValue)
            {
                //需要用的反序列化，将Redis存储的Byte[]，进行反序列化
                return JsonConvert.DeserializeObject<TEntity>(value);
            }
            else
            {
                return default(TEntity);
            }
        }

        public void Remove(string key)
        {
            _redisConnection.GetDatabase().KeyDelete(key);
        }

        public bool SetValue(string key, byte[] value)
        {
            return _redisConnection.GetDatabase().StringSet(key, value, TimeSpan.FromSeconds(120));
        }



        public async Task ClearAsync()
        {
            foreach (var endPoint in this.ConnectionRedis().GetEndPoints())
            {
                var server = this.ConnectionRedis().GetServer(endPoint);
                foreach (var key in server.Keys())
                {
                    await _redisConnection.GetDatabase().KeyDeleteAsync(key);
                }
            }
        }

        public async Task<bool> GetAsync(string key)
        {
            return await _redisConnection.GetDatabase().KeyExistsAsync(key);
        }

        public async Task<string> GetValueAsync(string key)
        {
            return await _redisConnection.GetDatabase().StringGetAsync(key);
        }

        public async Task<TEntity> GetAsync<TEntity>(string key)
        {
            var value = await _redisConnection.GetDatabase().StringGetAsync(key);
            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<TEntity>(value);
            }
            else
            {
                return default;
            }
        }

        public async Task RemoveAsync(string key)
        {
            await _redisConnection.GetDatabase().KeyDeleteAsync(key);
        }

        public async Task RemoveByKey(string key)
        {
            var redisResult = await _redisConnection.GetDatabase().ScriptEvaluateAsync(LuaScript.Prepare(
                //模糊查询：
                " local res = redis.call('KEYS', @keypattern) " +
                " return res "), new { @keypattern = key });

            if (!redisResult.IsNull)
            {
                var keys = (string[])redisResult;
                foreach (var k in keys)
                    _redisConnection.GetDatabase().KeyDelete(k);

            }
        }

        public async Task SetAsync(string key, object value, TimeSpan cacheTime)
        {
            if (value != null)
            {
                await _redisConnection.GetDatabase().StringSetAsync(key, JsonConvert.SerializeObject(value), cacheTime);
            }
        }

        public async Task<bool> SetValueAsync(string key, byte[] value)
        {
            return await _redisConnection.GetDatabase().StringSetAsync(key, value, TimeSpan.FromSeconds(120));
        }



    }
}
