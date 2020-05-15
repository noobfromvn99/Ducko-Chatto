using System;
using System.Runtime.Serialization;

namespace RandomChat.Models
{
    [Serializable]
    internal class ItemNotFoundExcpetion : Exception
    {
        public ItemNotFoundExcpetion()
        {
        }

        public ItemNotFoundExcpetion(string message) : base(message)
        {
        }

        public ItemNotFoundExcpetion(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ItemNotFoundExcpetion(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}