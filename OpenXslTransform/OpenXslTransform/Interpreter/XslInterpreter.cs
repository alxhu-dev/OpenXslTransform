using OpenXslTransform.Extensions;
using OpenXslTransform.Nodes;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace OpenXslTransform.Interpreter
{
    internal class XslInterpreter
    {
        public XslInterpreter()
        {
        }

        public INode Parse(Stream stream)
        {
            XDocument xDocument = XDocument.Load(stream);

            XElement stylesheetElement = GetXslStylesheetElement(xDocument);

            if (stylesheetElement == null)
            {
                // TODO: Try processing Literal Result Elements
                // https://www.w3.org/TR/xslt-10/#result-element-stylesheet
                throw new NotImplementedException("Document does not have any XSL elements or the stylesheet consits of just a literal reuslt element.");
            }

            return NodeInterpreterProvider.GetNodeInterpreter(stylesheetElement).Interpret(stylesheetElement);
        }

        private XElement GetXslStylesheetElement(XDocument xDocument)
        {
            if (xDocument == null)
                throw new ArgumentNullException(nameof(xDocument));

            return GetXslStylesheetElement(xDocument.Root);
        }
        private XElement GetXslStylesheetElement(XElement xElement)
        {
            if (xElement == null)
                throw new ArgumentNullException(nameof(xElement));

            if (IsStylehseetElement(xElement))
            {
                return xElement;
            }
            else if (xElement.HasElements)
            {
                foreach(XElement childElement in xElement.Elements())
                {
                    XElement stylesheetElement = GetXslStylesheetElement(childElement);
                    if (stylesheetElement != null)
                        return stylesheetElement;
                }
            }

            return default;
        }

        private bool IsStylehseetElement(XElement xElement)
        {
            return xElement.NodeType == XmlNodeType.Element &&
                xElement.NamespacePrefix().Equals("xsl") &&
                (xElement.Name.LocalName.Equals("stylesheet") || xElement.Name.LocalName.Equals("transform"));
        }
    }
}
