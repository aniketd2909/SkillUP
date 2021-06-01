using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Services.User
{
    [Serializable]
    internal class RoleNotFoundException : Exception
    {
        public RoleNotFoundException()
        {
        }

        public RoleNotFoundException(string message) : base(message)
        {
        }

        public RoleNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected RoleNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}