using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Controllers
{
    [Serializable]
    internal class UpdateException : Exception
    {
        public UpdateException()
        {
        }

        public string ErrorMessage()
        {
            return "Id doesn't exisist..";
        }
        public UpdateException(string message) : base(message)
        {
        }

        public UpdateException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UpdateException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}