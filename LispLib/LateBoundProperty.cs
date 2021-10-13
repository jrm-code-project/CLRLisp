namespace LispLib
{
    internal class LateBoundProperty
    {
        private readonly string propertyName;

        public LateBoundProperty (string propertyName) {
            this.propertyName = propertyName;
        }
    }
}