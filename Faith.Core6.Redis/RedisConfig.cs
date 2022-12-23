using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.Redis
{
    public class RedisConfig
    {
        public string RedisKey { get; set; }
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Password { get; set; }
        public string Timeout { get; set; }
        public string Db { get; set; }
        public string Port { get; set; }
    }
}
