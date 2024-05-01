using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using OpenXslTransform.Nodes;

namespace OpenXslTransform.Interpreter.NodeInterpreters
{
    internal abstract class NodeInterpreterBase : INodeInterpreter
    {
        private readonly Dictionary<string, Type> _nodeDictionary = new Dictionary<string, Type>();

        public NodeInterpreterBase()
        {
            InitializeNodeDictionary(_nodeDictionary);
        }

        protected abstract void InitializeNodeDictionary(Dictionary<string, Type> nodeDictionary);


        public INode Interpret(XElement xElement)
        {
            if (_nodeDictionary.TryGetValue(xElement.Name.LocalName, out Type t) && t.GetInterfaces().Contains(typeof(INode)))
            {
                INode node = (INode)Activator.CreateInstance(t);
                node.Interpret(xElement);
                return node;
            }

            throw new NotImplementedException();
        }
    }
}
