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
    }
}
