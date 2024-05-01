using OpenXslTransform.Extensions;
using OpenXslTransform.Interpreter.NodeInterpreters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OpenXslTransform.Interpreter
{
    internal static class NodeInterpreterProvider
    {


        private static readonly List<NodeInterpreterDefinition> _nodeInterpreterDefinitions = PrepareNodeInterpreterDefinitions();
        private static List<NodeInterpreterDefinition> PrepareNodeInterpreterDefinitions()
        {
            return new List<NodeInterpreterDefinition>
            {
                new NodeInterpreterDefinition("xsl", "http://www.w3.org/1999/XSL/Transform", new XslNodeInterpreter())
            };
        }

        public static INodeInterpreter GetNodeInterpreter(XElement xElement)
        {
            string prefixOfXElement = InterpretationRuntime.Instance.TryToResolveAlias(xElement.NamespacePrefix());

            // Try to find the node interpreter by prefix
            NodeInterpreterDefinition nodeInterpreterDefinition = _nodeInterpreterDefinitions.Find(d => d.DefaultPrefix.Equals(prefixOfXElement));
            if (nodeInterpreterDefinition == null)
                throw new Exception($"Node interpreter not found for prefix '{prefixOfXElement}'!");

            return nodeInterpreterDefinition.NodeInterpreter;
        }

        private class NodeInterpreterDefinition
        {
            public string DefaultPrefix { get; set; }
            public string Namespace { get; set; }
            public INodeInterpreter NodeInterpreter { get; set; }

            public NodeInterpreterDefinition(string defaultPrefix, string @namespace, INodeInterpreter nodeInterpreter)
            {
                DefaultPrefix = defaultPrefix ?? throw new ArgumentNullException(nameof(defaultPrefix));
                Namespace = @namespace ?? throw new ArgumentNullException(nameof(@namespace));
                NodeInterpreter = nodeInterpreter ?? throw new ArgumentNullException(nameof(nodeInterpreter));
            }
        }
    }
}
