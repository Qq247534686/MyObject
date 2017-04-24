using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SpringMVC.Models
{
    public class User:IUser
    {
        public string Name { get; set; }
        public Person Person { get; set; }
        public string Add(int a, int b)
        {
            return Name+"今年"+Person.Age+"会算"+a +"+"+ b+"="+(a+b).ToString();
        }
    }
}