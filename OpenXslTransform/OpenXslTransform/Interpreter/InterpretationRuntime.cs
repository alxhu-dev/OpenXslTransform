using System;
using System.Collections.Generic;
using System.Text;

namespace OpenXslTransform.Interpreter
{
    internal class InterpretationRuntime
    {
        public static InterpretationRuntime Instance { get; private set; } = new InterpretationRuntime();

        public Dictionary<string, string> NamespaceAlias { get; private set; } = new Dictionary<string, string>();
        public string TryToResolveAlias(string namespacePrefix)
        {
            if (NamespaceAlias.TryGetValue(namespacePrefix, out string aliasPrefix))
                return aliasPrefix;

            return namespacePrefix;
        }

        public void Reset()
        {
            NamespaceAlias = new Dictionary<string, string>();
        }
    }
}
