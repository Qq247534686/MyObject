using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.ComponentModel;
namespace 线程池
{
    class Program
    {
        static void Main(string[] args)
        {
            Run run = new Run();
            MonitorSample theMonitorSample = new MonitorSample();
            //Thread th1 = new Thread(run.MonitorMethod);
            //th1.IsBackground = true;
            //th1.Start("线程一");
            //Thread th2 = new Thread(run.MonitorMethod);
            //th2.IsBackground = true;
            //th2.Start("线程二");

            MonitorSample obj = new MonitorSample();
            Thread tProduce = new Thread(obj.Produce);
            Thread tConsume = new Thread(obj.Consume);
            tProduce.Start(tProduce);
            tConsume.Start(tConsume);
            Console.ReadLine();

        }
       
    }
}
