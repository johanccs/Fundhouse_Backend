using FH.Domain.Entities;
using MediatR;

namespace FH.Application.Quote.Requests.QueryRequests
{
    public sealed class GetQuoteRequest : IRequest<QuoteEntity>
    {
        public QuoteEntity QuoteEntity { get; set; }

        public GetQuoteRequest(QuoteEntity quoteEntity)
        {
            QuoteEntity = quoteEntity;
        }
    }
}
