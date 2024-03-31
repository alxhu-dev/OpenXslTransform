using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter.Nodes
{
    public abstract class NodeFactoryBase : INodeFactory
    {
        public INode ParseNode(XmlReader xmlReader)
        {
            INode node = GetNodeByName(xmlReader.Name);
            node.Parse(xmlReader);
            return node;
        }

        public abstract INode GetNodeByName(string name);

    }
}
