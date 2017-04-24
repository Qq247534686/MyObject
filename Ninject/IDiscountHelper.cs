using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject
{

    //折扣计算接口
    public interface IDiscountHelper
    {
        decimal ApplyDiscount(decimal totalParam);
    }
    //默认折扣计算器
    public class DefaultDiscountHelper : IDiscountHelper
    {
        public decimal DiscountSize { get; set; }
        public decimal FullValue { get; set; }
        public DefaultDiscountHelper()
        { 
        
        }
        public DefaultDiscountHelper(decimal fullValue)
        {
            FullValue = fullValue;
        }
      
        public decimal ApplyDiscount(decimal totalParam)
        {
            return (totalParam - (DiscountSize / FullValue * totalParam));
        } 
    }
}
