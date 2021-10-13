using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LispLib
{
    class LateBoundStaticMethod : IApplicable
    {   
        private readonly string methodName;
        private readonly Type type;

        public LateBoundStaticMethod (Type type, string methodName) {
            this.type = type;
            this.methodName = methodName;
        }

        public object? Apply (List arglist) {
            Type[] argtypes = arglist.MapToVector (o => o is null ? typeof(void) : o.GetType ());
            MethodInfo? methodInfo = type.GetMethod (methodName, argtypes);
            if (methodInfo == null) throw new NotImplementedException ();
            return methodInfo.Invoke (null, arglist.ToVector ());
        }
    }
}
