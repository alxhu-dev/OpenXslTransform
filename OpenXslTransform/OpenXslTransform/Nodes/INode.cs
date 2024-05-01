using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OpenXslTransform.Nodes
{
    internal interface INode
    {
        IEnumerable<INode> Children { get; }
        void Interpret(XElement xElement);
    }
}
