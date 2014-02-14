using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace STE
{
    public class GetXml
    {
        public XmlReader GetXMLTest()
        {
            XmlReader xmlTest = XmlReader.Create("TestSet.xml");
            return xmlTest;
        }

        public XmlReader GetXMLTask()
        {
            XmlReader xmlTask = XmlReader.Create("TaskSet.xml");
            return xmlTask;
        }

    }
}

