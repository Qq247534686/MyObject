using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using Spring.Objects.Factory;

namespace SpringNet
{
    class Program
    {
        static void Main(string[] args)
        {
            //SpringNet
            读取自定义位置文件();



        }
        public static void 读取配置文件()
        {
            IApplicationContext ctx = ContextRegistry.GetContext();
            IUserInfoService lister = (IUserInfoService)ctx.GetObject("UserInfoService");
            Console.WriteLine(lister.ShowMsg());
        }
        public static void 读取自定义位置文件()
        {
            string[] xmlFiles = new string[]
            {
                "assembly://SpringNet/SpringNet.Xml/services.xml",
                "assembly://SpringNet/SpringNet.Xml/newservices.xml"
            };
            IApplicationContext ctx = new XmlApplicationContext(xmlFiles);
            IObjectFactory obj = (IObjectFactory)ctx;
            var type = obj.GetObject("UserInfoService") as IUserInfoService;
            Console.WriteLine(type.ShowMsg());

        }
        public static void 使用Ninject()
        {
            //Ninject
            IKernel kerner = new StandardKernel();
            kerner.Bind<Person>().ToSelf().WithPropertyValue("Age", 100);
            kerner.Bind<IUserInfoService>().To<UserInfoService>().WithPropertyValue("USER_NAME", "LJC").WithPropertyValue("PERSON", kerner.Get<Person>());
            Console.WriteLine(kerner.Get<IUserInfoService>().ShowMsg());
        }
    }
}
