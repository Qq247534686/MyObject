using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject
{
    /// <summary>
    /// 计算器
    /// </summary>
    public class LinqValueCalculator : IValueCalculator
    {
        private IDiscountHelper discounter;
        public LinqValueCalculator(IDiscountHelper discountParam)
        {
            this.discounter = discountParam;
        }

        public decimal ValueProducts(params Product[] products)
        {
            return discounter.ApplyDiscount(products.Sum(p => p.Price));
        } 
    }
}
