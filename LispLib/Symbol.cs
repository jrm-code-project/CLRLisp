using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LispLib
{
    public class Symbol
    {
        private static readonly Dictionary<string, Symbol> internTable = new();
        private readonly string name;

        private Symbol (string name) 
        {
            this.name = name;
            internTable.Add (name, this);
        }

        public object Eval (Environment environment) {
            if (name.Contains ('.')) {
                int lastDot = name.LastIndexOf ('.');
                string typeName = name.Substring (0, lastDot);
                string methodName = name[(lastDot + 1)..];
                Type? type = null;
                foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                    type = assembly.GetType (typeName);
                    if (type != null) break;
                }
                if (type == null) throw new NotImplementedException ();
                return new LateBoundStaticMethod (type, methodName);
            } else {
                return environment.Lookup (this);
            }
        }

        public static Symbol Intern (string name) 
        {
            if (!internTable.TryGetValue (name, out Symbol? answer)) {
                answer = new Symbol (name);
            }
            return answer;
        }

        public string Name => name;
    }
}
