using log4net;
using log4net.Config;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Timers;
using Topshelf;

namespace TopshelfDemo
{
    public class 继承接口模式 : ServiceControl 
    {
        readonly ILog _log = LogManager.GetLogger("errorMsg");
        readonly Timer _timer;
        public 继承接口模式()
        {
            _timer = new Timer(1000) { AutoReset = true };
            var logCfg = new FileInfo(AppDomain.CurrentDomain.BaseDirectory + "log4net.config");
            XmlConfigurator.ConfigureAndWatch(logCfg);
            _timer.Elapsed += (sender, eventArgs) => {
                _log.Error(string.Format("It is {0} and all is well", DateTime.Now));

                //Console.WriteLine("It is {0} and all is well", DateTime.Now);
            
            };
        }
        public static void Run()
        {
            HostFactory.Run(x =>                                 //1
            {
                x.Service<继承接口模式>();
                x.RunAsLocalSystem();         
                x.SetDescription("Sample Topshelf Host服务的描述");        //安装服务后，服务的描述
                x.SetDisplayName("Stuff显示名称");                       //显示名称
                x.SetServiceName("Stuff服务名称");                       //服务名称
            });                                               //10
        }

        public bool Start(HostControl hostControl)
        {
            _timer.Start();
            return true;
        }

        public bool Stop(HostControl hostControl)
        {
            _timer.Stop();
            return true;
        }
    }
}
