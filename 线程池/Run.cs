using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
namespace 线程池
{
    public class Run
    {
        public object theObject = new object();
        public void NotLock(object name)
        {
            for (int i = 0; i < 999; i++)
            {
                Console.WriteLine((string)name + "----------->" + i);
            }
        }

        public void HaveLock(object name)
        {
            lock (this)
            {
                for (int i = 0; i < 999; i++)
                {
                    Console.WriteLine((string)name + "----------->" + i);
                }
            }
        }
        public void MonitorMethod(object name)
        {
            lock (theObject)
            {
                Monitor.Pulse(theObject);
                for (int i = 0; i < 999; i++)
                {
                    Console.WriteLine((string)name + "----------->" + i);
                }
                Monitor.Wait(theObject, 1000);
            }
        }

    }
}
