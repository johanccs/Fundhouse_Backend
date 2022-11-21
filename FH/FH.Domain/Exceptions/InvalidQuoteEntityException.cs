using System;

namespace FH.Domain.Exceptions
{
    [Serializable]
    public sealed class InvalidQuoteEntityException: Exception
    {
        public InvalidQuoteEntityException(string message):base(message)
        {

        }
    }
}
