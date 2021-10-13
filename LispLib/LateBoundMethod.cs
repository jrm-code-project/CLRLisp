using System;
using System.Reflection;

namespace LispLib
{
    internal class LateBoundMethod : IApplicable
    {
        private readonly string methodName;
        private readonly BindingFlags bindingFlags;

        public LateBoundMethod (string name) {
            if (name.EndsWith ('#')) {
                this.methodName = name[..^1];
                this.bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.IgnoreCase;
            } else {
                this.methodName = name;
                this.bindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase;
            }
        }

        public object? Apply (List arglist) {
            object? target = arglist.Car;
            if (target == null) throw new NotImplementedException ();
            Type targetType = target.GetType ();
            Type[] argTypes = arglist.Cdr.MapToVector (o => o is null ? typeof (void) : o.GetType ());
            MethodInfo? methodInfo = targetType.GetMethod (methodName, bindingFlags, null, argTypes, null);
            if (methodInfo == null) throw new NotImplementedException ();
            object?[] argvector = arglist.Cdr.ToVector ();
            return methodInfo.Invoke (target, argvector);
        }
    }
}