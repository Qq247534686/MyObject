using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;
using Topshelf;

namespace TopshelfDemo
{
    //常用模式
   public class TownCrier
    {

        readonly Timer _timer;
        public TownCrier()
        {
            _timer = new Timer(1000) { AutoReset = true };
            _timer.Elapsed += (sender, eventArgs) => { Console.WriteLine("It is {0} and all is well", DateTime.Now); };
        }
        public void Start() { _timer.Start(); }
        public void Stop() { _timer.Stop(); }
        public static void Run()
        {
            HostFactory.Run(x =>                                 //1
            {
                x.Service<TownCrier>(s =>                        //2
                {
                    s.ConstructUsing(name => new TownCrier());     //配置一个完全定制的服务,对Topshelf没有依赖关系。常用的方式。
                    //the start and stop methods for the service
                    s.WhenStarted(tc => tc.Start());              //4
                    s.WhenStopped(tc => tc.Stop());               //5
                });
                x.RunAsLocalSystem();                            // 服务使用NETWORK_SERVICE内置帐户运行。身份标识，有好几种方式，如：x.RunAs("username", "password");  x.RunAsPrompt(); x.RunAsNetworkService(); 等

                x.SetDescription("Sample Topshelf Host服务的描述");        //安装服务后，服务的描述
                x.SetDisplayName("Stuff显示名称");                       //显示名称
                x.SetServiceName("Stuff服务名称");                       //服务名称
            });                                               //10
        }
    }
   
}
