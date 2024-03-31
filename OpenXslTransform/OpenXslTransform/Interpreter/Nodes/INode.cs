using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter.Nodes
{
    public interface INode
    {
        void Parse(XmlReader xmlReader);
    }
}
