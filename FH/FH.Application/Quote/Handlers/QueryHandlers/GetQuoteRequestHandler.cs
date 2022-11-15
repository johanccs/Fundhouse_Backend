using FH.Application.Common.Abstractions;
using FH.Application.Quote.Requests.QueryRequests;
using FH.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace FH.Application.Quote.Handlers.QueryHandlers
{
    public class GetQuoteRequestHandler : IRequestHandler<GetQuoteRequest, QuoteEntity>
    {
        #region Readonly Fields

        private readonly IQuoteService _quoteService;

        #endregion

        #region ctor

        public GetQuoteRequestHandler(IQuoteService quoteService)
        {
            _quoteService = quoteService;
        }

        #endregion

        #region Methods

        public async Task<QuoteEntity> Handle(GetQuoteRequest request, CancellationToken cancellationToken)
        {
            return await _quoteService.GetQuote(request.QuoteEntity);
        }

        #endregion
    }
}
