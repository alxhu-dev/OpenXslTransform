using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter.Nodes
{
    internal abstract class NodeFactoryBase : INodeFactory
    {
        private readonly string _prefix;

        public NodeFactoryBase(string prefix)
        {
            _prefix = prefix;
        }


        public INode ParseNode(XmlReader xmlReader)
        {
            if (!xmlReader.Prefix.Equals(_prefix))
                throw new Exception($"Wrong node factory! (Expected prefix: '{_prefix}', actual prefix: '{xmlReader.Prefix}')");

            INode node = GetNodeByName(xmlReader.LocalName);
            node.Parse(xmlReader);
            return node;
        }

        public abstract INode GetNodeByName(string name);

    }
}
