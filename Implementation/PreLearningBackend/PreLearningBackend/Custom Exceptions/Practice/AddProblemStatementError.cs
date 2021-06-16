using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Controllers
{
    [Serializable]
    internal class AddProblemStatementError : Exception
    {
        public AddProblemStatementError()
        {
        }

        public AddProblemStatementError(string message) : base(message)
        {
        }
        public string message()
        {
            return "Error At Adding Problem Statement";
        }
        public AddProblemStatementError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddProblemStatementError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}