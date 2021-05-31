using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Services.Blocker
{
    [Serializable]
    internal class InvalidBlockerSoution : Exception
    {
        public InvalidBlockerSoution()
        {
        }

        public InvalidBlockerSoution(string message) : base(message)
        {
        }

        public InvalidBlockerSoution(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected InvalidBlockerSoution(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}