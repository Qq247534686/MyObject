using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Common;
using Quartz.Impl;
using System.Threading;

namespace Quartz
{
    class Program
    {
        /*
         Install-Package Quartz
         Install-Package Common.Logging.Log4Net1211
         Install-Package log4net
         Install-Package Topshelf
         Install-Package Topshelf.Log4Net
         */
        static void Main(string[] args)
        {
            //从工厂中获取一个调度器实例化

            MyJob.ss();
            for (int i = 0; i < 10000; i++)
            {
                Console.WriteLine(i+"");
                Thread.Sleep(1000);
            }
            
        }
    }
}
