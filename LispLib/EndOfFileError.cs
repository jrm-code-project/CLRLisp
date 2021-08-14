using System;
using System.Runtime.Serialization;

namespace LispLib
{
    [Serializable]
    internal class EndOfFileError : Exception
    {
        public EndOfFileError () {
        }

        public EndOfFileError (string message) : base (message) {
        }

        public EndOfFileError (string message, Exception innerException) : base (message, innerException) {
        }

        protected EndOfFileError (SerializationInfo info, StreamingContext context) : base (info, context) {
        }
    }
}