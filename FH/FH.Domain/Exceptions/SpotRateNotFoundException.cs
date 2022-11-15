using System;

namespace FH.Domain.Exceptions
{
    [Serializable]
    public class SpotRateNotFoundException:Exception
    {
        public SpotRateNotFoundException(
            string baseCcur, string exchCcur) : base($"Spot Rate {baseCcur}/{exchCcur} not found")
        {
        }
    }
}
