using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter.Nodes
{
    internal abstract class NodeBase : INode
    {
        private List<INode> _childNodes;
        public List<INode> ChildNodes => _childNodes ?? (_childNodes = new List<INode>());

        public void Parse(XmlReader xmlReader)
        {
            // try to read content
            if (xmlReader.HasValue)
            {
                OnParseValue(xmlReader.Value);
            }

            // try to read current attributes
            if (xmlReader.HasAttributes)
            {
                for (int i = 0; i < xmlReader.AttributeCount; i++)
                {
                    xmlReader.MoveToAttribute(i);
                    OnParseAttribute(xmlReader.Name, xmlReader.Value);
                }
            }
            while (xmlReader.Read())
            {
                switch (xmlReader.NodeType)
                {
                    case XmlNodeType.Element:
                        INode node = NodeFactories.GetByNamespace(xmlReader.Prefix).ParseNode(xmlReader);
                        ChildNodes.Add(node);
                        break;

                    case XmlNodeType.EndElement:
                        return;
                }
            }
        }

        protected virtual void OnParseAttribute(string name, string value)
        {
        }

        protected virtual void OnParseValue(string value)
        {
        }
    }
}
