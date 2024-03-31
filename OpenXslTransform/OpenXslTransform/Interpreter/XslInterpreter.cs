using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;

namespace OpenXslTransform.Interpreter
{
    public class XslInterpreter
    {

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
                            throw new NotImplementedException();

                    }
                }
            }
        }


    }
}
