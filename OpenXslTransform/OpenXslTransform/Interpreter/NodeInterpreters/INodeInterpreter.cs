using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;
using OpenXslTransform.Nodes;

namespace OpenXslTransform.Interpreter.NodeInterpreters
{
    internal interface INodeInterpreter
    {
        INode Interpret(XElement xElement);
    }
}
