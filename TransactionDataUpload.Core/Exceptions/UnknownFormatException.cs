using System;

namespace TransactionDataUpload.Core.Exceptions
{
    public class UnknownFormatException : Exception
    {
        public UnknownFormatException(string message) : base(message) { }
        public UnknownFormatException(string message, Exception innerException) : base(message, innerException) { }
    }
}
