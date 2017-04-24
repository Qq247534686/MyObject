using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ninject
{
    /// <summary>
    /// 具体的产品
    /// </summary>
    public class Product
    {
        public decimal Price { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
    }
}
