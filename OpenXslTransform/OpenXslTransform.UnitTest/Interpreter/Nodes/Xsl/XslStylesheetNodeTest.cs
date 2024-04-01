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
            using XmlReaderHelper helper = new XmlReaderHelper(xml);
            helper.ReadToNextElement();
            Assert.That(helper.XmlReader.Name, Is.EqualTo("xsl:stylesheet"));

            XslStylesheetNode xslStylesheetNode = new XslStylesheetNode();
            xslStylesheetNode.Parse(helper.XmlReader);

            Assert.That(xslStylesheetNode.Version, Is.EqualTo("1.0"));
        }

        [Test]
        public void StylesheetNodeWithContent()
        {
            string xml = @"<xsl:stylesheet version=""1.0"" xmlns:xsl=""http://www.w3.org/1999/XSL/Transform""><xsl:template match=""/""></xsl:template></xsl:stylesheet>";
            using XmlReaderHelper helper = new XmlReaderHelper(xml);
            helper.ReadToNextElement();
            Assert.That(helper.XmlReader.Name, Is.EqualTo("xsl:stylesheet"));

            XslStylesheetNode xslStylesheetNode = new XslStylesheetNode();
            xslStylesheetNode.Parse(helper.XmlReader);

            Assert.That(xslStylesheetNode.Version, Is.EqualTo("1.0"));
        }

    }
}
