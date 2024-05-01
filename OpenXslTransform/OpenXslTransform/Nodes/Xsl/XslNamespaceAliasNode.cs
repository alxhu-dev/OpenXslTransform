using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OpenXslTransform.Nodes.Xsl
{
    internal class XslNamespaceAliasNode : NodeBase
    {
        public string StylesheetPrefix { get; set; }
        public string ResultPrefix { get; set; }

        public override void Interpret(XElement xElement)
        {
            StylesheetPrefix = xElement.Attribute(XName.Get("stylesheet-prefix"))?.Value ?? throw new ArgumentException();
            ResultPrefix = xElement.Attribute(XName.Get("result-prefix"))?.Value ?? throw new ArgumentException();
        }
    }
}
