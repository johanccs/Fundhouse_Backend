using FH.Application.Common.Abstractions;
using FH.Domain.Entities;
using FH.Domain.Exceptions;
using FH.Domain.ValueObjects.Quotes;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FH.Infrastructure.Services
{
    public class QuoteService: IQuoteService
    {
        #region Readonly Fields

        private readonly IExternalCurrencyApi _externalApi;

        #endregion

        #region Ctor

        public QuoteService(IExternalCurrencyApi externalApi)
        {
            _externalApi = externalApi;
        }

        #endregion

        #region Methods

        public async Task<QuoteEntity> GetQuote(QuoteEntity quote)
        {
            string jsonResult = await _externalApi.GetExchangeRateJson(quote.BaseCcy, quote.QuoteCcy, quote.Amount);

            if (jsonResult == null)
                throw new SpotRateNotFoundException(quote.BaseCcy, quote.QuoteCcy);

            try
            {
                Root spotRate = JsonSerializer.Deserialize<Root>(jsonResult);
                return await Task.FromResult(
                    new QuoteEntity(
                        spotRate.base_code, spotRate.target_code, quote.Amount,
                        Convert.ToDecimal(spotRate.conversion_rate),
                        Convert.ToDecimal(spotRate.conversion_result)));
            }
            catch (RootSerializationException)
            {
                throw;
            }
        }

        #endregion
    }
}
