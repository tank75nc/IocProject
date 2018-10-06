using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyIocContainer.Tests
{
    class VeryComplexType
    {
        public System.Xml.XmlDocument xml;
        public System.Text.StringBuilder sb;
        public VeryComplexType(System.Xml.XmlDocument pXml, System.Text.StringBuilder pSb)
        {
            xml = pXml;
            sb = pSb;
        }
    }
}
