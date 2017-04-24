using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    public class Configuration
    {
        public string Host { get; set; }
        public int Port { get; set; }
        /// <summary>
        /// Socket 是否正在使用 Nagle 算法。
        /// </summary>
        public bool NoDelaySocket { get; set; }

        public Configuration()
        {
            Host = "127.0.0.1";
            Port = 6379;
            NoDelaySocket = false;
        }
    }
}
