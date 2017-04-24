using log4net;
using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Quartz_Topshelf
{
    public sealed class TestJob : IJob
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof(TestJob));

        public void Execute(IJobExecutionContext context)
        {
            _logger.InfoFormat("TestJob测试");

            //Console.WriteLine("123213");
        }
    }
}
