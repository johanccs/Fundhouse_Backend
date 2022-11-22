using FH.Application.Common.Abstractions;
using FH.Domain.Entities;
using FH.Infrastructure.Services;
using FH.Tests.Services.MockServices;
using System;
using System.Threading.Tasks;
using Xunit;

namespace FH.Tests.Services
{
    public class QuoteTestService
    {
        [Fact]
        public async Task GetValidQuoteTest()
        {
            IExternalCurrencyApi mockExternal = new MockExternalServices();
            IQuoteService mockQuoteService = new QuoteService(mockExternal);

            var quote = await mockQuoteService.GetQuote(new QuoteEntity("ZAR", "USD", 100));

            Assert.NotNull(quote);
            Assert.True(quote.ConversionRate == 1);
            Assert.True(quote.QuoteAmount == quote.ConversionRate * quote.Amount);
        }
    }
}
