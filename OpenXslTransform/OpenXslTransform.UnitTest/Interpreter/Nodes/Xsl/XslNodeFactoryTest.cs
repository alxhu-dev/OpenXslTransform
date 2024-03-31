using OpenXslTransform.Interpreter.Nodes.Xsl;
using OpenXslTransform.Interpreter.Nodes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXslTransform.UnitTest.Interpreter.Nodes.Xsl
{
    internal class XslNodeFactoryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetNodeByNameStylesheet()
        {
            INode node = XslNodeFactory.Instance.GetNodeByName("stylesheet");
            Assert.That(node.GetType(), Is.SameAs(typeof(XslStylesheetNode)));
        }

        [Test]
        public void GetNodeByNameInvalid()
        {
            Assert.Throws<NotImplementedException>(() => XslNodeFactory.Instance.GetNodeByName("invalid"));
        }

        [Test]
        public void GetNodeByNameNull()
        {
            Assert.Throws<ArgumentNullException>(() => XslNodeFactory.Instance.GetNodeByName(null));
        }

        [Test]
        public void GetNodeByNameEmpty()
        {
            Assert.Throws<ArgumentException>(() => XslNodeFactory.Instance.GetNodeByName(string.Empty));
        }
    }
}
