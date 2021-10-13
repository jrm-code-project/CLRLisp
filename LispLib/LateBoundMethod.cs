using System;
using System.Reflection;

namespace LispLib
{
    internal class LateBoundMethod : IApplicable
    {
        private readonly string methodName;

        public LateBoundMethod (string name) {
            this.methodName = name;
        }

        public object? Apply (List arglist) {
            object? target = arglist.Car;
            if (target == null) throw new NotImplementedException ();
            Type targetType = target.GetType ();
            Type[] argTypes = arglist.Cdr.MapToVector (o => o is null ? typeof (void) : o.GetType ());
            MethodInfo? methodInfo = targetType.GetMethod (methodName, argTypes);
            if (methodInfo == null) throw new NotImplementedException ();
            object?[] argvector = arglist.Cdr.ToVector ();
            return methodInfo.Invoke (target, argvector);
        }
    }
}