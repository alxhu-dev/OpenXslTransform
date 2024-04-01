using OpenXslTransform.Interpreter.Nodes;
using OpenXslTransform.Interpreter.Nodes.Xsl;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter
{
    internal class XslInterpreter
    {
        public INode RootNode { get; private set; }

        public XslInterpreter()
        {
        }

        public void Parse(Stream stream)
        {
            using (XmlReader xmlReader = XmlReader.Create(stream))
            {
                while (xmlReader.Read())
                {
                    switch (xmlReader.NodeType)
                    {
                        case XmlNodeType.Element:
                            RootNode = XslNodeFactory.Instance.ParseNode(xmlReader);
                            break;

                    }
                }
            }
        }
    }
}
