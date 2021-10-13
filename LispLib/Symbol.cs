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

        public object? Eval (Environment environment) {
            if (name.Contains ('.')) {
                if (name.StartsWith('.')) {
                    if (name.EndsWith('$')) {
                        return new LateBoundProperty (name[1..^1]);
                    } else {
                        return new LateBoundMethod (name[1..]);
                    }
                } else {
                    int lastDot = name.LastIndexOf ('.');
                    string typeName = name.Substring (0, lastDot);
                    Type? type = null;
                    foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies ()) {
                        type = assembly.GetType (typeName, false, true);
                        if (type != null) break;
                    }
                    if (type == null) throw new NotImplementedException ();
                    if (name.EndsWith ('$')) {
                        string propertyName = name[(lastDot + 1)..^1];
                        return new LateBoundStaticProperty (type, propertyName);
                    } else {
                        string methodName = name[(lastDot + 1)..];
                        return new LateBoundStaticMethod (type, methodName);
                    }
                }
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
