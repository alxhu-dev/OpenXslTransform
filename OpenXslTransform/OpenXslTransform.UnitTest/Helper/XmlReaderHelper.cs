using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace OpenXslTransform.UnitTest.Helper
{
    internal class XmlReaderHelper : IDisposable
    {
        private Stream _stream;
        public XmlReader XmlReader { get; private set; }

        public XmlReaderHelper(string s)
        {
            _stream = StreamHelper.AsStream(s);
            XmlReader = XmlReader.Create(_stream);
        }

        public void ReadToNextElement()
        {
            while (XmlReader.Read())
                if (XmlReader.NodeType == XmlNodeType.Element)
                    return;
        }

        public void Dispose()
        {
            XmlReader?.Dispose();
            _stream?.Dispose();
        }

    }
}
