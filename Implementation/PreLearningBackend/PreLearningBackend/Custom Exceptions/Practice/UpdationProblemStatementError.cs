using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Controllers
{
    [Serializable]
    internal class UpdationProblemStatementError : Exception
    {
        public UpdationProblemStatementError()
        {
        }

        public UpdationProblemStatementError(string message) : base(message)
        {
        }
        public string message()
        {
            return "Error while updating Problem Statement";
        }
        public UpdationProblemStatementError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected UpdationProblemStatementError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}