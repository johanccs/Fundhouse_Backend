namespace FH.Domain.ValueObjects
{
    public sealed class Currency
    {
        public string CurrencyId { get; set; }
        public string CurrencyName{ get; set; }

        public Currency(string currencyId, string currencyName)
        {
            CurrencyId = currencyId;
            CurrencyName = currencyName;
        }
    }
}
