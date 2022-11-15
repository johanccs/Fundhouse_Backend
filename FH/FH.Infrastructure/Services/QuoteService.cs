using FH.Application.Common.Abstractions;
using FH.Domain.Entities;
using FH.Domain.Exceptions;
using FH.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FH.Infrastructure.Services
{
    public class QuoteService: IQuoteService
    {
        #region Readonly Fields

        private readonly List<SpotRate> _entities;

        #endregion

        #region Ctor

        public QuoteService()
        {
            _entities = new List<SpotRate>
            {
                new SpotRate("zar", "usd", 0.058M),
                new SpotRate("usd","zar", (1/0.058M)),
                new SpotRate("zar", "gbp", 0.049M),
                new SpotRate("gbp", "zar", (1/0.049M)),
                new SpotRate("usd","gbp", 0.84m),
                new SpotRate("gbp","usd", (1/0.84m)),
            };
        }

        #endregion

        #region Methods

        public async Task<QuoteEntity> GetQuote(QuoteEntity quote)
        {
            var internalSpotRate = _entities.Where(x => x.BaseCurrencyCode == quote.BaseCcy)
                                            .Where(y => y.ExchangeCurencyCode == quote.QuoteCcy)
                                            .FirstOrDefault();
            if (internalSpotRate == null)
                throw new SpotRateNotFoundException(quote.BaseCcy, quote.QuoteCcy);

            return await Task.FromResult(QuoteEntity.CalculateQuoteAmount(internalSpotRate, quote.Amount));
        }

        #endregion
    }
}
