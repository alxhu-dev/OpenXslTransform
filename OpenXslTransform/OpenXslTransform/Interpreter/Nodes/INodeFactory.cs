using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter.Nodes
{
    public interface INodeFactory
    {
        INode ParseNode(XmlReader xmlReader);
    }
}
