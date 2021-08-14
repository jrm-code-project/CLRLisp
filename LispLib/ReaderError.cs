using System;
using System.Runtime.Serialization;

namespace LispLib
{
    [Serializable]
    internal class ReaderError : Exception
    {
        public ReaderError () {
        }

        public ReaderError (string message) : base (message) {
        }

        public ReaderError (string message, Exception innerException) : base (message, innerException) {
        }

        protected ReaderError (SerializationInfo info, StreamingContext context) : base (info, context) {
        }
    }
}