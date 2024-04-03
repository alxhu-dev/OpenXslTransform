using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace OpenXslTransform.Interpreter.Nodes._PLAIN
{
    internal class PlainNodeFactory : NodeFactoryBase
    {
        public static PlainNodeFactory Instance = new PlainNodeFactory();
        public PlainNodeFactory() : base(null)
        {
        }

        public override INode GetNodeByName(string name)
        {
            return new PlainNode();
        }
    }
}
