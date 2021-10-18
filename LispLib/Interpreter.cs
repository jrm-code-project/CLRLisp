using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispLib
{
    public class Interpreter
    {
        public static void Initialize () {
            Boot.Read().Mapc (expr => Eval (expr, Environment.User));
        }

        public static object? Apply (object? o, List arglist) {
            return
                (o is null) ? throw new NotImplementedException ()
                : (o is IApplicable oApplicable) ? oApplicable.Apply (arglist)
                : throw new NotImplementedException ();
        }

        public static object? Eval (object? o, Environment environment) {
            return
                (o is null) ? o
                : (o is IEval oEval) ? oEval.Eval (environment)
                : o;
        }

    }
}
