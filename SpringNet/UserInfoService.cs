using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpringNet
{
    public class UserInfoService : IUserInfoService
    {
        public string USER_NAME { get; set; }
        public Person PERSON { get; set; }
        public string ShowMsg()
        {
            return "Hello World:\n" + USER_NAME + ":年龄是:" + PERSON.Age;
        }
    }
}
