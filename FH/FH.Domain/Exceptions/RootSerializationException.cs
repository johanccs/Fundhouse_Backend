using System;

namespace FH.Domain.Exceptions
{
    [Serializable]
    public sealed class RootSerializationException: Exception
    {
        public RootSerializationException(string message) : base($"The following Root Serialization exception occurred: {message}")
        {
        }
    }
}
