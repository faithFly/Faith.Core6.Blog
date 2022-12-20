using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faith.Core6.Redis
{
    public class RedisConfig
    {
        public string Name { get; set; }
        public string Ip { get; set; }
        public string Password { get; set; }
        public int Port { get; set; }
        public int Timeout { get; set; }
        public int Db { get; set; }
        public string Key { get; set; }
    }
}
