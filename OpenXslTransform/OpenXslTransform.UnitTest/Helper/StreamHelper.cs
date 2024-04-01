using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXslTransform.UnitTest.Helper
{
    internal static class StreamHelper
    {
        public static Stream AsStream(string s)
        {
            return new MemoryStream(Encoding.Unicode.GetBytes(s));
        }
    }
}
