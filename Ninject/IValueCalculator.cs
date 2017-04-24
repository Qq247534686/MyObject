using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ninject
{
    /// <summary>
    /// 那些功能的扩张
    /// </summary>
    public interface IValueCalculator
    {
        decimal ValueProducts(params Product[] products);
    }
}
