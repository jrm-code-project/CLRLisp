using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispLib
{
    public class Environment
    {
        private static readonly Environment global = new();
        private static readonly Environment user = new(global);

        private static readonly object notFound = new();

        private readonly Dictionary<Symbol, object?> bindings;
        private readonly Environment? parent;

        private Environment () {
            this.bindings = new Dictionary<Symbol, object?> ();
            this.parent = null;
        }

        public Environment (Environment parent) {
            this.bindings = new Dictionary<Symbol, object?> ();
            this.parent = parent;
        }

        public Environment Extend (List names, List values) {
            Environment result = new(this);
            List.Mapc ((name, value) => {
                if (name is null) throw new NotImplementedException ();
                result.bindings.Add ((Symbol) name, value);
            }, names, values);              
            return result;
        }

        public object? Lookup (Symbol symbol) {
            if (bindings.TryGetValue (symbol, out object? answer))
                return answer;
            else if (parent != null)
                return parent.Lookup (symbol);
            else
                return notFound;
        }

        public static object NotFound => notFound;

        public static Environment User => user;
    }
}
