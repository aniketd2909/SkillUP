using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Controllers
{
    [Serializable]
    internal class ExceptionWhileAdding : Exception
    {
        public ExceptionWhileAdding()
        {
        }

        public string ErrorMessage()
        {
            return "Failed to add to the feed";
        }
        public ExceptionWhileAdding(string message) : base(message)
        {
        }

        public ExceptionWhileAdding(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ExceptionWhileAdding(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}