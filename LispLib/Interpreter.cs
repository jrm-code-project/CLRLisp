using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispLib
{
    class Interpreter
    {
        public static object? Eval (object? o, Environment environment) {
            return
                (o is null) ? o
                : (o is List oList) ? oList.Eval (environment)
                : (o is string oString) ? oString
                : (o is Symbol oSymbol) ? oSymbol.Eval (environment)
                : throw new NotImplementedException();
        }

        public static object? Apply (object? o, List arglist) {
            return
                (o is null) ? throw new NotImplementedException ()
                : (o is LateBoundStaticMethod oLBSM) ? oLBSM.Apply (arglist)
                : throw new NotImplementedException ();
        }
    }
}
