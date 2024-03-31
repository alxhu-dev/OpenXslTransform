using OpenXslTransform.IntegrationTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXslTransform.IntegrationTest
{
    internal abstract class TestBase
    {
        protected abstract string XslFilename { get; }

        protected Stream XslFileStream { get; private set; } = Stream.Null;

        [SetUp]
        public void Setup()
        {
            if (!string.IsNullOrEmpty(XslFilename))
            {
                XslFileStream = EmbeddedResourceReader.ReadResource(XslFilename) ?? throw new Exception($"Xsl file not found: {XslFilename}");
            }
        }

        [TearDown]
        public void Teardown()
        {
            XslFileStream.Dispose();
        }
    }
}
