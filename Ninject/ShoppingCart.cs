using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject
{
    /// <summary>
    /// 购物车
    /// </summary>
    public class ShoppingCart
    {
        IValueCalculator calculator;
        public int tValue { get; set; }
        public ShoppingCart(IValueCalculator calculator)
        {
            this.calculator = calculator;
        }
        public decimal CalculateStockValue()
        {
            Product[] products = { 
            new Product {Name = "西瓜", Category = "水果", Price = 2.3M}, 
            new Product {Name = "苹果", Category = "水果", Price = 4.9M}, 
            new Product {Name = "空心菜", Category = "蔬菜", Price = 2.2M}, 
            new Product {Name = "地瓜", Category = "蔬菜", Price = 1.9M} 
        };
            //计算商品总价钱 
            decimal totalValue = calculator.ValueProducts(products);
            return totalValue;
        }

        public void SavePrice()
        {
            Console.WriteLine(tValue.ToString());
        }



    }
}
