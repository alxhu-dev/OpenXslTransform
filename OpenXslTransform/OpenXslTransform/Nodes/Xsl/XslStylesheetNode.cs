using OpenXslTransform.Interpreter;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OpenXslTransform.Nodes.Xsl
{
    internal class XslStylesheetNode : NodeBase
    {
        public string Version { get; set; }
        public override void Interpret(XElement xElement)
        {
            Version = xElement.Attribute(XName.Get("version"))?.Value ?? null;

            InterpretChildren(xElement);
        }

        protected override void OnChildCreated(INode childNode)
        {
            if (childNode is XslNamespaceAliasNode namespaceAlias)
            {
                if (InterpretationRuntime.Instance.NamespaceAlias.ContainsKey(namespaceAlias.StylesheetPrefix))
                    throw new Exception($"There is already an alias for '{namespaceAlias.StylesheetPrefix}'!");

                InterpretationRuntime.Instance.NamespaceAlias[namespaceAlias.StylesheetPrefix] = namespaceAlias.ResultPrefix;
            }
        }
    }
}
