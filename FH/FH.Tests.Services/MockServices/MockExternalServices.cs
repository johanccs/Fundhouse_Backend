using FH.Application.Common.Abstractions;
using FH.Domain.Entities;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FH.Tests.Services.MockServices
{
    public class MockExternalServices : IExternalCurrencyApi
    {
        public async Task<string> GetCurrencySymbolsJson()
        {
            var symbol = new Domain.ValueObjects.Root();

            symbol.success = true;
            symbol.symbols.ZAR = "South African Rand";
            symbol.symbols.USD = "United States Dollar";

            return await Task.FromResult(JsonSerializer.Serialize(symbol));
        }

        public async Task<string> GetExchangeRateJson(string baseSymbol, string excSymbol, decimal amount)
        {
            var mockReturnValue = new Domain.ValueObjects.Quotes.Root();
            mockReturnValue.result = "success";
            mockReturnValue.documentation = "https://www.exchangerate-api.com/docs";
            mockReturnValue.terms_of_use = "https://www.exchangerate-api.com/terms";
            mockReturnValue.time_last_update_unix = 1669075202;
            mockReturnValue.time_last_update_utc = "Tue, 22 Nov 2022 00:00:02 +0000";
            mockReturnValue.time_next_update_unix = 1669161602;
            mockReturnValue.time_next_update_utc = "Wed, 23 Nov 2022 00:00:02 +0000";
            mockReturnValue.base_code = baseSymbol;
            mockReturnValue.target_code = excSymbol;
            mockReturnValue.conversion_rate = 1;
            mockReturnValue.conversion_result = 100;

            return await Task.FromResult(JsonSerializer.Serialize(mockReturnValue));
        }

        public Task<string> GetRateHistoryJson(string baseSymbol, string excSymbol)
        {
            throw new NotImplementedException();
        }
    }
}
