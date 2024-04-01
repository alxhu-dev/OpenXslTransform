using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter.Nodes.Xsl
{
    internal class XslStylesheetNode : NodeBase
    {
        public string Version { get; set; }

        protected override void OnParseAttribute(string name, string value)
        {
            switch (name)
            {
                case "version":
                    Version = value;
                    break;
            }
        }
    }
}
