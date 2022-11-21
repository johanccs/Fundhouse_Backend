using FH.Application.Common.Abstractions;
using FH.Domain.ValueObjects;
using FH.Services.Contracts;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading.Tasks;

namespace FH.Services.Services
{
    public class CurrencyService : ICurrencyService
    {
        #region Readonly Fields

        private readonly List<Currency> _currencies;
        private readonly IExternalCurrencyApi _externalApi;

        #endregion

        #region Ctor

        public CurrencyService(IExternalCurrencyApi externalApi)
        {
            _externalApi = externalApi;
        }

        #endregion

        #region Methods

        public async Task<Symbols> GetCurrenciesAsync()
        {
            string jsonResult = await _externalApi.GetCurrencySymbolsJson();

            Root currencyResult = JsonSerializer.Deserialize<Root>(jsonResult);

            return currencyResult.symbols;
        }

        #endregion
    }
}
