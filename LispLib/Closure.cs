using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispLib
{
    class Closure : IApplicable
    {
        private readonly List lambda;
        private readonly Environment environment;

        public Closure (List lambda, Environment environment) {
            this.lambda = lambda;
            this.environment = environment;
        }

        public object? Apply (List arglist) {
            if (lambda.Cadr is null) throw new NotImplementedException ();
            return lambda.Cddr.EvalBody (environment.Extend ((List) lambda.Cadr, arglist));
        }
    }
}
