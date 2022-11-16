using FH.Application.Common.Abstractions;
using FH.Application.Quote.Requests.QueryRequests;
using FH.Domain.DbModels;
using FH.Domain.Entities;
using FH.Services.Contracts;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FH.Application.Quote.Handlers.QueryHandlers
{
    public class GetQuoteRequestHandler : IRequestHandler<GetQuoteRequest, QuoteEntity>
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
            var quote = await _quoteService.GetQuote(request.QuoteEntity);
          
            _ = await _historyRepo.AddToHistory(quote.BaseCcy, quote.QuoteCcy, quote.Date, quote.Value);

          

            return quote;
        }

        #endregion
    }
}
