using OpenXslTransform.Interpreter.Nodes.Xsl;
using OpenXslTransform.UnitTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXslTransform.UnitTest.Interpreter.Nodes.Xsl
{
    internal class XslTemplateNodeTest
    {
        [Test]
        public void SimpleTemplateNode()
        {
            string xml = @"<xsl:template name=""Test_Template"" match=""Xpath/Test""></xsl:template>";
            using XmlReaderHelper helper = new XmlReaderHelper(xml);
            helper.ReadToNextElement();
            Assert.That(helper.XmlReader.Name, Is.EqualTo("xsl:template"));

            XslTemplateNode xslTemplateNode = new XslTemplateNode();
            xslTemplateNode.Parse(helper.XmlReader);

            Assert.That(xslTemplateNode.Name, Is.EqualTo("Test_Template"));
            Assert.That(xslTemplateNode.Match, Is.EqualTo("Xpath/Test"));
        }
    }
}
