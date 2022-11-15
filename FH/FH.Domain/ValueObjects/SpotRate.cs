using System;

namespace FH.Domain.ValueObjects
{
    public sealed class SpotRate
    {
        public string BaseCurrencyCode { get; private set; }
        public string ExchangeCurencyCode { get; private set; }
        public DateTime Date { get; private set; }
        public decimal Value { get; private set; }

        public SpotRate(string baseCcode, string excCcode, decimal val)
        {
            BaseCurrencyCode = baseCcode;
            ExchangeCurencyCode = excCcode;
            Date = DateTime.Now;
            Value = val;
        }
    }
}
