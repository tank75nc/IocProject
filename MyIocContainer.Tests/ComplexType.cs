using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIocContainer.Tests
{
    public class ComplexType
    {
        public System.Xml.XmlDocument xml;
        public ComplexType(System.Xml.XmlDocument pXml)
        {
            xml = pXml;
        }
    }
}
