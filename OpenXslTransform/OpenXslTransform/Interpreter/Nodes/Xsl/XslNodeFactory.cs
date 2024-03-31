using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter.Nodes.Xsl
{
    public class XslNodeFactory : NodeFactoryBase
    {
        public static readonly XslNodeFactory Instance = new XslNodeFactory();

        public override INode GetNodeByName(string name)
        {
            if (name == null)
                throw new ArgumentNullException("name");

            if (name.Length == 0)
                throw new ArgumentException("'name' must not be empty.", "name");

            switch (name)
            {
                case "stylesheet": return new XslStylesheetNode();
                default: throw new NotImplementedException($"Unknown node name: {name}");
            }
        }
    }
}
