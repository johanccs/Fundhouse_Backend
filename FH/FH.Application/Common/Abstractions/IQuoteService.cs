using FH.Domain.Entities;
using System.Threading.Tasks;

namespace FH.Application.Common.Abstractions
{
    //Retrieve the value by exchange rate
    public interface IQuoteService
    {
        Task<QuoteEntity> GetQuote(QuoteEntity quote);
    }
}
