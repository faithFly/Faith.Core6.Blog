using Hangfire.Redis;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.HangFire
{
    public class HangFireHelper
    {
        private readonly ILogger<HangFireHelper> _logger;
        private readonly IConfiguration _configuration;

        public HangFireHelper(ILogger<HangFireHelper> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }
        public void ReadHangFireConfig() {
            try
            {
                HangFireConnectionString.connectionString = _configuration["Hangfire:Config:ConnectionString"];
                HangFireConnectionString.db = int.Parse(_configuration["Hangfire:Config:Db"]);
            }
            catch (Exception ex)
            {
                _logger.LogError($"读取配置出错:" + ex.Message);
            }
        }
        private void HangFireStorage() {
            //默认使用redis进行定时任务调度
            HangFireConnectionString.hangfireStorage = new RedisStorage(HangFireConnectionString.connectionString, new RedisStorageOptions
            {
                Db = HangFireConnectionString.db,
                FetchTimeout = TimeSpan.FromMilliseconds(10)//间隔多久读取一次，最低15s，如图写了10s 其实实际也是15s
            });
        }
    }
}
