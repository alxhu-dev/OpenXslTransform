using OpenXslTransform.Interpreter;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OpenXslTransform
{
    public class XslTransform
    {

        public void Load(Stream stream)
        {
            InterpretationRuntime.Instance.Reset();

            XslInterpreter xslInterpreter = new XslInterpreter();
            xslInterpreter.Parse(stream);
        }

        public void Transform(Stream inputXml, Stream outputXml)
        {

        }
    }
}
