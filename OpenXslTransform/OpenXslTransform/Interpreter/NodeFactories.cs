﻿using OpenXslTransform.Interpreter.Nodes;
using OpenXslTransform.Interpreter.Nodes._PLAIN;
using OpenXslTransform.Interpreter.Nodes.Xsl;
using System;
using System.Collections.Generic;
using System.Text;

namespace OpenXslTransform.Interpreter
{
    internal static class NodeFactories
    {
        public static INodeFactory GetByNamespace(string ns)
        { 
            switch (ns)
            {
                case null:
                case "":
                    return PlainNodeFactory.Instance;

                case "xsl":
                    return XslNodeFactory.Instance;

                default:
                    throw new NotImplementedException($"Unknown namespace: {ns}");
            }
        }
    }
}
