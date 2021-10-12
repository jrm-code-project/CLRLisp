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

        private readonly Dictionary<Symbol, object> bindings;
        private readonly Environment? parent;

        private Environment () {
            this.bindings = new Dictionary<Symbol, object> ();
            this.parent = null;
        }

        public Environment (Environment parent) {
            this.bindings = new Dictionary<Symbol, object> ();
            this.parent = parent;
        }

        public object Lookup (Symbol symbol) {
            if (bindings.TryGetValue (symbol, out object? answer))
                return answer;
            else if (parent != null)
                return parent.Lookup (symbol);
            else
                throw new NotImplementedException ();
        }

        public static Environment User => user;
    }
}
