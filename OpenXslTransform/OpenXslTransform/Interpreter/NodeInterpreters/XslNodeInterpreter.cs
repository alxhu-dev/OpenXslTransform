using OpenXslTransform.Nodes.Xsl;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OpenXslTransform.Interpreter.NodeInterpreters
{
    internal class XslNodeInterpreter : NodeInterpreterBase
    {
        protected override void InitializeNodeDictionary(Dictionary<string, Type> nodeDictionary)
        {
            nodeDictionary.Add("stylesheet", typeof(XslStylesheetNode));
            nodeDictionary.Add("transform", typeof(XslStylesheetNode));
        }
    }
}
