using System;
using System.Runtime.Serialization;

namespace BLL.Exceptions
{
    [Serializable]
    public class DbResultException : Exception
    {
        public DbResultException()
        {
        }

        public DbResultException(string message) : base(message)
        {
        }

        public DbResultException(string message, Exception inner) : base(message, inner)
        {
        }

        protected DbResultException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}