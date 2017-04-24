using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quartz
{
    public class MyJob:IJob
    {
        public static DateTime dt = new DateTime();
        public void Execute(IJobExecutionContext context)
        {
            dt = DateTime.Now;
            Console.WriteLine(dt.ToString("yyyy-MM-dd HH:mm:ss"));
        }
        public static void ss()
        {
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
