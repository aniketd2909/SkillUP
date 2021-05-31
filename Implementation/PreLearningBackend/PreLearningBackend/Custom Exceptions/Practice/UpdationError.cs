using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Controllers
{
    [Serializable]
    internal class UpdationError : Exception
    {
        public UpdationError()
        {
        }

        public UpdationError(string message) : base(message)
        {
        }
        public string message()
        {
            return "Error Occured while Updating Best Practices";
        }
        public UpdationError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UpdationError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}