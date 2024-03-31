using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenXslTransform.IntegrationTest.Helper
{
    internal static class EmbeddedResourceReader
    {
        public static Stream? ReadResource(string filename)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();
            
            string resourcePath = assembly.GetManifestResourceNames().Single(s => s.EndsWith(filename));
            return assembly.GetManifestResourceStream(resourcePath);
        }
    }
}
