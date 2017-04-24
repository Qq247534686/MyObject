using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Quartz;
using Common;
using Quartz.Impl;
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
            IScheduler scheduler = StdSchedulerFactory.GetDefaultScheduler();
            scheduler.Start();       //开启调度器
            IJobDetail job1 = JobBuilder.Create<MyJob>().WithIdentity("作业名称", "作业组").Build();//创建一个作业
            ITrigger trigger1 = TriggerBuilder.Create().WithIdentity("触发器名称", "触发器组")
                                       .StartNow()                        //现在开始
                                       .WithSimpleSchedule(x => x.WithIntervalInSeconds(1)         //触发时间，5秒一次。
                                           .RepeatForever())              //不间断重复执行
                                       .Build();
            scheduler.ScheduleJob(job1, trigger1);
            
        }
    }
}
