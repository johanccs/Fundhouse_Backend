using System;

namespace FH.Domain.Exceptions
{
    public class InvalidQuoteEntityException: Exception
    {
        public InvalidQuoteEntityException(string message):base(message)
        {

        }
    }
}
