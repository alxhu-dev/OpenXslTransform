using OpenXslTransform.Interpreter.Nodes.Xsl;
using OpenXslTransform.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpenXslTransform.UnitTest.Interpreter.Nodes.Xsl
{
    internal class XslStylesheetNodeTest
    {





        [Test]
        public void SimpleStylesheetNode()
        {
            string xml = @"<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform""></xsl:stylesheet>";
            using Stream stream = StreamHelper.AsStream(xml);
            using XmlReader xmlReader = XmlReader.Create(stream);
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        Assert.That(xmlReader.Name, Is.EqualTo("xsl:stylesheet"));

                        XslStylesheetNode xslStylesheetNode = new XslStylesheetNode();
                        xslStylesheetNode.Parse(xmlReader);

                        Assert.That(xslStylesheetNode.Version, Is.EqualTo("1.0"));

                        return;
                }
            }


        } 

    }
}
