using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace OpenXslTransform.Extensions
{
    internal static class XElementExtensions
    {
        public static string NamespacePrefix(this XElement xElement)
        {
            return xElement.GetPrefixOfNamespace(xElement.Name.Namespace);
        }
    }
}
