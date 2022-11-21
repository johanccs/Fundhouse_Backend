using System;

namespace FH.Domain.Exceptions
{
    [Serializable]
    public sealed class HistoryNullException: Exception
    {
        public HistoryNullException(string exceptionMsg) : base(exceptionMsg)
        {
        }
    }
}
