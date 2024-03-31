using OpenXslTransform.Interpreter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenXslTransform.IntegrationTest.Tests
{
    internal class EmptyStylesheetTests : TestBase
    {
        protected override string XslFilename => "EmptyStylesheet.xslt";

        [Test]
        public void ParseSuccessfully()
        {
            XslInterpreter xslInterpreter = new XslInterpreter();
            xslInterpreter.Parse(XslFileStream);
        }
    }
}
