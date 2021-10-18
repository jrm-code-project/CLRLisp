using System;
using System.Reflection;

namespace LispLib
{
    internal class LateBoundConstructor : IApplicable
    {
        private readonly Type type;
        private readonly BindingFlags bindingFlags;

        public LateBoundConstructor (Type type) {
            this.type = type;
            this.bindingFlags = BindingFlags.Static | BindingFlags.Public;
        }

        public object? Apply (List arglist) {
            Type[] argtypes = arglist.MapToVector (o => o is null ? typeof (void) : o.GetType ());
            ConstructorInfo? constructorInfo = type.GetConstructor (bindingFlags, null, argtypes, null);
            if (constructorInfo == null) throw new NotImplementedException ();
            return constructorInfo.Invoke (arglist.ToVector ());
        }
    }
}