using FH.Application.Common.Abstractions;
using FH.Domain.ValueObjects;
using FH.Services.Contracts;
using FH.Services.Services;
using FH.Tests.Services.MockServices;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FH.Tests.Services.Services
{
    public class CurrencyTestService
    {
        [Fact]
        public async Task GetExpectedCurrencies()
        {
            //Setup
            IExternalCurrencyApi mockExternal = new MockExternalServices();
            ICurrencyService mockCurrencyService = new CurrencyService(mockExternal);

            //Run service
            var mockSymbol = await mockCurrencyService.GetCurrenciesAsync();

            IEnumerable<Currency> currency = mockSymbol.GetType().GetProperties()
                .Where(x => x.PropertyType == typeof(string))
                .Select(x => new Currency(x.Name, x.GetValue(mockSymbol).ToString()));

            //Assert.True(currency.ToList().GetType() == typeof(List<Currency>));
            Assert.NotNull(currency);
            Assert.True(currency.ToList().Count > 0);
        }
    }
}
