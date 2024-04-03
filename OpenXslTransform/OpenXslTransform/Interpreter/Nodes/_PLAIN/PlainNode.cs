using System;
using System.Collections.Generic;
using System.Text;

namespace OpenXslTransform.Interpreter.Nodes._PLAIN
{
    internal class PlainNode : NodeBase
    {
        public List<Tuple<string, string>> Attributes { get; private set; } = new List<Tuple<string, string>>();
        public string Value { get; private set; }

        protected override void OnParseAttribute(string name, string value)
        {
            Attributes.Add(Tuple.Create(name, value));
        }

        protected override void OnParseValue(string value)
        {
            Value = value;
        }
    }
}
