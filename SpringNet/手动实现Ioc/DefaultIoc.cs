using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace SpringNet.手动实现Ioc
{
    public class DefaultIoc
    {
        Dictionary<string, object> objectArray = new Dictionary<string, object>();
        public DefaultIoc(string fileName)
        {
            InsterObject(fileName);
        }
        private void InsterObject(string fileName)
        {
            XElement xml = XElement.Load(fileName);
            var obj = from ele in xml.Elements("object") select ele;
            objectArray = obj.ToDictionary(
                k => k.Attribute("name").Value,
                v =>
                {
                    Type type = Type.GetType(v.Attribute("type").Value);
                    return Activator.CreateInstance(type);
                }
                );
        }

        public object getObject(string name)
        {
            object obj = null;
            if (objectArray.ContainsKey(name))
            {
                obj = objectArray[name];
            }
            return obj;
        }

    }
}
