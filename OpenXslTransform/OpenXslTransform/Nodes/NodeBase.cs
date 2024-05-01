using OpenXslTransform.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OpenXslTransform.Nodes
{
    internal abstract class NodeBase : INode
    {
        private readonly List<INode> _children = new List<INode>();
        public IEnumerable<INode> Children => _children;

        protected INode Parent { get; private set; }

        public abstract void Interpret(XElement xElement);

        protected void InterpretChildren(XElement xElement)
        {
            foreach(XElement child in xElement.Elements())
            {
                INode childNode = NodeInterpreterProvider.GetNodeInterpreter(child).Interpret(child);
                ((NodeBase)childNode).Parent = this;
                _children.Add(childNode);
            }
        }

        protected virtual void OnChildCreated(INode childNode)
        {
        }
    }
}
