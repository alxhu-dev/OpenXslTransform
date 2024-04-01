using System;
using System.Collections.Generic;
using System.Text;

namespace OpenXslTransform.Interpreter.Nodes.Xsl
{
    internal class XslTemplateNode : NodeBase
    {
        public string Name { get; set; }
        public string Match { get; set; }

        protected override void OnParseAttribute(string name, string value)
        {
            switch (name)
            {
                case "name":
                    Name = value;
                    break;

                case "match":
                    Match = value;
                    break;
            }
        }

    }
}
