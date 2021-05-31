using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Controllers
{
    [Serializable]
    internal class AddBestPracticeError : Exception
    {
        public AddBestPracticeError()
        {
        }

        public AddBestPracticeError(string message) : base(message)
        {
        }
        public string message()
        {
            return "Error Occured while Adding Best Practices";
        }
        public AddBestPracticeError(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected AddBestPracticeError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}