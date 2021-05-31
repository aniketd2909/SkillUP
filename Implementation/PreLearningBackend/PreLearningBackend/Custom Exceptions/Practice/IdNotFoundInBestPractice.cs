using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Services.Practice
{
    [Serializable]
    internal class IdNotFoundInBestPractice : Exception
    {
        public IdNotFoundInBestPractice()
        {
        }

        public IdNotFoundInBestPractice(string message) : base(message)
        {
        }
        public string message()
        {
            return "Id not Found";
        }
        public IdNotFoundInBestPractice(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected IdNotFoundInBestPractice(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}