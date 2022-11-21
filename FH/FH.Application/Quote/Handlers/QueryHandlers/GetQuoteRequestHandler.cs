using FH.Application.Common.Abstractions;
using FH.Application.Quote.Requests.QueryRequests;
using FH.Domain.Entities;
using FH.Services.Contracts;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace FH.Application.Quote.Handlers.QueryHandlers
{
    public sealed class GetQuoteRequestHandler : IRequestHandler<GetQuoteRequest, QuoteEntity>
    {
        #region Readonly Fields

        private readonly IQuoteService _quoteService;
        private readonly IHistoryRepo _historyRepo;

        #endregion

        #region ctor

        public GetQuoteRequestHandler(IQuoteService quoteService, IHistoryRepo historyRepo)
        {
            _quoteService = quoteService;
            _historyRepo = historyRepo;
        }

        #endregion

        #region Methods

        public async Task<QuoteEntity> Handle(GetQuoteRequest request, CancellationToken cancellationToken)
        {
            QuoteEntity quote = await _quoteService.GetQuote(request.QuoteEntity);
            IEnumerable<Domain.DbModels.History> historyResult = await _historyRepo.GetHistoryByCurrencyCode(quote.BaseCcy, quote.QuoteCcy);

            if (historyResult.ToList().Count == 0)
                _ = await _historyRepo.AddToHistory(quote.BaseCcy, quote.QuoteCcy, quote.Date, quote.ConversionRate);

            IEnumerable<Domain.DbModels.History> today = historyResult.ToList().Where(
                x => x.Date.Year == quote.Date.Year &&
                x.Date.Month == quote.Date.Month &&
                x.Date.Day == quote.Date.Day);

            if (today.Count() == 0)
            {
                _ = await _historyRepo.AddToHistory(quote.BaseCcy, quote.QuoteCcy, quote.Date, quote.ConversionRate);
            }

            //quote.History = historyResult;
            quote.History = new List<Domain.DbModels.History>();

            return quote;
        }

        #endregion
    }
}
