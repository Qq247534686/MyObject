using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace 线程池
{
    public class MonitorSample
    {
        private int n = 1; // 生产者和消费者共同处理的数据    
        private int max = 99;
        private object monitor = new object();

        public void Produce(object obj) // 生产
        {
            lock (monitor)
            {
                for (; n <= max; n++)
                {
                    if (n <= max)
                    {
                        Console.WriteLine("妈妈：第" + n.ToString() + "块蛋糕做好了");
                    }
                    else
                    {
                        ((Thread)obj).Abort();
                       
                    }

                    // Pulse 方法不用调用是因为另一个线程中用的是 Wait(object,int) 方法 
                    // 该方法使被阻止线程进入了同步对象的就绪队列 
                    // 是否需要脉冲激活是 Wait 方法一个参数和两个参数的重要区别 
                    Monitor.Pulse(monitor);

                    // 调用 Wait 方法释放对象上的锁并阻止该线程（线程状态为 WaitSleepJoin） 
                    // 该线程进入到同步对象的等待队列，直到其它线程调用 Pulse 使该线程进入到就绪队列中 
                    // 线程进入到就绪队列中才有条件争夺同步对象的所有权 
                    // 如果没有其它线程调用 Pulse/PulseAll 方法，该线程不可能被执行 
                    Monitor.Wait(monitor);
                }
            }
        }

        public void Consume(object obj) // 消费
        {
            lock (monitor)
            {
                while (true)
                {
                    // 通知等待队列中的线程锁定对象状态的更改，但不会释放锁 
                    // 接收到 Pulse 脉冲后，线程从同步对象的等待队列移动到就绪队列中 
                    // 注意：最终能获得锁的线程并不一定是得到 Pulse 脉冲的线程 
                    Monitor.Pulse(monitor);

                    // 释放对象上的锁并阻止当前线程，直到它重新获取该锁 
                    // 如果指定的超时间隔已过，则线程进入就绪队列 
                    // 该方法只有在线程重新获得锁时才有返回值
                    // 在超时等待时间内就获得了锁,返回结果为 true,否则为 false
                    // 有时可以利用这个返回结果进行一个代码的分支处理
                    Monitor.Wait(monitor, 1000);
                    if (n <= max)
                    {
                        Console.WriteLine("孩子：开始吃第" + n.ToString() + "块蛋糕");
                    }
                    else
                    {
                        ((Thread)obj).Abort();
                    }
                }
            }
        }
    }
}
