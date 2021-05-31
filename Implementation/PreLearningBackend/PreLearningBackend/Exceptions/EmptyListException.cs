﻿using System;
using System.Runtime.Serialization;

namespace PreLearningBackend.Services.Blocker
{
    [Serializable]
    internal class EmptyListException : Exception
    {
        public EmptyListException()
        {
        }

        public EmptyListException(string message) : base(message)
        {
        }

        public EmptyListException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected EmptyListException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}