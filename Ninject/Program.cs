using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
namespace Ninject
{
  
    class Program
    {
        static void Main(string[] args)
        {
            /*
             当我们需要使用IValueCalculator接口的实现时（通过Get方法），它便为我们创建LinqValueCalculator类的实例。而当创建LinqValueCalculator类的实例时，它检查到这个类依赖IDiscountHelper接口。于是它又创建一个实现了该接口的DefaultDiscounterHelper类的实例，并通过构造函数把该实例注入到LinqValueCalculator类。然后返回LinqValueCalculator类的一个实例，并赋值给IValueCalculator接口的对象
             */
            IKernel kernel = new StandardKernel();
            kernel.Bind<IValueCalculator>().To<LinqValueCalculator>();
            //kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 5M).WithPropertyValue("FullValue", 9M);
            kernel.Bind<IDiscountHelper>().To<DefaultDiscountHelper>().WithPropertyValue("DiscountSize", 5M).WithConstructorArgument<decimal>(4M);
            kernel.Bind<ShoppingCart>().ToSelf().WithPropertyValue("tValue",100);
            ShoppingCart theShoppingCart = kernel.Get<ShoppingCart>();
            theShoppingCart.SavePrice();
            Console.WriteLine(theShoppingCart.CalculateStockValue().ToString("c"));
            Console.ReadKey();

            //Ninject的绑定方式分为：一般绑定、指定值绑定、自我绑定、派生类绑定和条件绑定。
        }
    }
}
