using System;

namespace FH.Domain.Exceptions
{
    [Serializable]
    public sealed class SpotRateNotFoundException:Exception
    {
        public SpotRateNotFoundException(
            string baseCcur, string exchCcur) : base($"Spot Rate {baseCcur}/{exchCcur} not found")
        {
        }
    }
}
