using System;
using System.Reflection;

namespace LispLib
{
    internal class LateBoundStaticProperty : IApplicable
    {
        private readonly Type type;
        private readonly string propertyName;

        public LateBoundStaticProperty (Type type, string propertyName) {
            this.type = type;
            this.propertyName = propertyName;
        }

        public object? Apply (List arglist) {
            Type[] types = arglist.MapToVector (o => o == null ? typeof (void) : o.GetType ());
            PropertyInfo? propertyInfo = type.GetProperty (propertyName, types);
            if (propertyInfo == null) throw new NotImplementedException ();
            return propertyInfo.GetValue (null, arglist.ToVector());
        }
    }
}