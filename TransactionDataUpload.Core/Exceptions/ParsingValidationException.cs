using System;

namespace TransactionDataUpload.Core.Exceptions
{
    public class ParsingValidationException : Exception
    {
        public ParsingValidationException(string message) : base(message) { }
        public ParsingValidationException(string message, Exception innerException) : base(message, innerException) { }
    }
}
