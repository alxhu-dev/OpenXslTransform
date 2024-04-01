using OpenXslTransform.Interpreter;
using OpenXslTransform.Interpreter.Nodes;
using OpenXslTransform.Interpreter.Nodes.Xsl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXslTransform.UnitTest.Interpreter
{
    internal class NodeFactoriesTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestGetByNamespaceXsl()
        {
            INodeFactory nodeFactory = NodeFactories.GetByNamespace("xsl");
            Assert.That(nodeFactory, Is.EqualTo(XslNodeFactory.Instance));
        }

        [Test]
        public void TestGetByNamespaceNotImplemented()
        {
            Assert.Throws<NotImplementedException>(() => NodeFactories.GetByNamespace("NotImplementedNamespace"));
        }
    }
}
