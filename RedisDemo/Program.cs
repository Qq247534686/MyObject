using ServiceStack.Redis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace RedisDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            RedisBaseClient redis = new RedisBaseClient();
            var result = redis.SendCommand(RedisCommand.INFO);
            Console.WriteLine(result);
            Console.ReadKey();
        }
    }
}
