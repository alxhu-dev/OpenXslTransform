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
            if (!s.Contains("xmlns:xsl="))
            {
                int firstTagClosePosition = s.IndexOf('>');
                s = $"{s.Substring(0, firstTagClosePosition)} xmlns:xsl=\"http://www.w3.org/1999/XSL/Transform\">{s.Substring(firstTagClosePosition + 1)}";
            }

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
