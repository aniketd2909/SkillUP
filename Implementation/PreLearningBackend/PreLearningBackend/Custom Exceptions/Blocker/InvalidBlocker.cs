using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Services.Blocker
{
    [Serializable]
    internal class InvalidBlocker : Exception
    {
        public InvalidBlocker()
        {
        }

        public InvalidBlocker(string message) : base(message)
        {
        }

        public InvalidBlocker(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBlocker(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}