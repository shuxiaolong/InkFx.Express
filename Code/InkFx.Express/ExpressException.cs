using System;
using System.Runtime.Serialization;

namespace InkFx.Express
{
    /// <summary>
    /// InkFx.Express 主要异常
    /// </summary>
    [Serializable]
    public class ExpressException : Exception
    {
        public ExpressException() : base() { }
        public ExpressException(string message) : base(message) { }
        public ExpressException(string message, Exception innerException) : base(message, innerException) { }
        public ExpressException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
