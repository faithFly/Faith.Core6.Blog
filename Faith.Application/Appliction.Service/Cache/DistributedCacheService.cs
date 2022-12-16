using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Application.Appliction.Service.Cache
{
    public class DistributedCacheService
    {
        private readonly IDistributedCache _cache;

        public DistributedCacheService(IDistributedCache cache)
        {
            _cache = cache;
        }

        /// <summary>
        /// 根据KEY获取对象值 
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T">返回类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public T Get<T>(string key)
        {
            if (key == default)
                throw new ArgumentNullException();
            var byteValue = _cache.Get(key);
            var stringValue = Encoding.UTF8.GetString(byteValue);
            return JsonConvert.DeserializeObject<T>(stringValue);
        }

        /// <summary>
        /// 根据KEY获取值 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回一个String对象</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public string Get(string key)
        {
            if (key == default)
                throw new ArgumentNullException();
            var byteValue = _cache.Get(key);
            return Encoding.UTF8.GetString(byteValue);
        }

        /// <summary>
        /// 根据KEY获取对象值，异步方式调用 
        /// </summary>
        /// <param name="key"></param>
        /// <typeparam name="T">返回类型</typeparam>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<T> GetAsync<T>(string key)
        {
            if (key == default)
                throw new ArgumentNullException();
            var byteValue = await _cache.GetAsync(key);
            var stringValue = Encoding.UTF8.GetString(byteValue);
            return JsonConvert.DeserializeObject<T>(stringValue);
        }
        /// <summary>
        /// 根据KEY获取值，异步方式调用 
        /// </summary>
        /// <param name="key"></param>
        /// <returns>返回String对象</returns>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task<string> GetAsync(string key)
        {
            if (key == default)
                throw new ArgumentNullException();
            var byteValue = await _cache.GetAsync(key);
            return Encoding.UTF8.GetString(byteValue);
        }
        /// <summary>
        /// 设置一个key-value对 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expire">过期时间</param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public void Set<T>(string key, T value, TimeSpan? expire = null)
        {
            if (key == default)
                throw new ArgumentNullException();
            if (value == null)
                throw new ArgumentNullException();
            string stringValue = null;
            if (!(value is string s))
                stringValue = JsonConvert.SerializeObject(value);
            else
                stringValue = s;

            var byteValue = Encoding.UTF8.GetBytes(stringValue);
            _cache.Set(key, byteValue, new DistributedCacheEntryOptions()
            {
                SlidingExpiration = expire
            });
        }
        /// <summary>
        /// 设置一个key-value对，异步方式调用 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expire"></param>
        /// <typeparam name="T"></typeparam>
        /// <exception cref="ArgumentNullException"></exception>
        public async Task SetAsync<T>(string key, T value, TimeSpan? expire = null)
        {
            if (key == default)
                throw new ArgumentNullException();
            if (value == null)
                throw new ArgumentNullException();
            string stringValue = null;
            if (!(value is string s))
                stringValue = JsonConvert.SerializeObject(value);
            else
                stringValue = s;

            var byteValue = Encoding.UTF8.GetBytes(stringValue);
            await _cache.SetAsync(key, byteValue, new DistributedCacheEntryOptions()
            {
                SlidingExpiration = expire
            });
        }

        /// <summary>
        /// 刷新过期时间
        /// </summary>
        /// <param name="key"></param>
        public void Refresh(string key)
        {
            _cache.Refresh(key);
        }

        /// <summary>
        /// 刷新过期时间，异步方式调用 
        /// </summary>
        /// <param name="key"></param>
        public async Task RefreshAsync(string key)
        {
            await _cache.RefreshAsync(key);
        }

        /// <summary>
        /// 移除一个KEY-VALUE对 
        /// </summary>
        /// <param name="key"></param>
        public void Remove(string key)
        {
            {
                _cache.Remove(key);
            }
        }
        /// <summary>
        /// 移除一个KEY-VALUE对 ，异步方式调用 
        /// </summary>
        /// <param name="key"></param>
        public async Task RemoveAsync(string key)
        {
            {
                await _cache.RemoveAsync(key);
            }
        }
    }
}
