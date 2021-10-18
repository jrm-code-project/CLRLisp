using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LispLib
{
    public class Symbol : IEval
    {
        private static readonly Dictionary<string, Symbol> internTable = new();
        private readonly string name;

        private Symbol (string name) 
        {
            this.name = name;
            internTable.Add (name, this);
        }

        static Type? GetType (string name) {
            Type? answer = null;
            foreach (Assembly assembly in AppDomain.CurrentDomain.GetAssemblies()) {
                answer = assembly.GetType (name, false, true);
                if (answer != null) break;
            }
            return answer;
        }

        public object? Eval (Environment environment) {
            object? value = environment.Lookup (this);
            if (value == Environment.NotFound) {
                if (name.Contains ('.')) {
                    if (name.EndsWith ('.')) {
                        string typeName = name[0..^1];
                        Type? type = GetType (typeName);
                        if (type == null) throw new NotImplementedException ();
                        return new LateBoundConstructor (type);
                    } else if (name.StartsWith ('.')) {
                        if (name.EndsWith ('$')) {
                            return new LateBoundProperty (name[1..^1]);
                        } else {
                            return new LateBoundMethod (name[1..]);
                        }
                    } else {
                        int lastDot = name.LastIndexOf ('.');
                        string typeName = name.Substring (0, lastDot);
                        Type? type = GetType (typeName);
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
                    throw new NotImplementedException ();
                }
            } else {
                return value;
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
