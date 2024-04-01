using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter.Nodes.Xsl
{
    internal class XslNodeFactory : NodeFactoryBase
    {
        public static readonly XslNodeFactory Instance = new XslNodeFactory();

        public XslNodeFactory() : base("xsl")
        {
        }

        public override INode GetNodeByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("'name' must not be empty or whitespace only.", "name");

            switch (name)
            {
                case "stylesheet": return new XslStylesheetNode();
                case "template": return new XslTemplateNode();
                default:
                    throw new NotImplementedException($"Unknown node name: {GetFullNodeName(name)}");
            }
        }
    }
}
