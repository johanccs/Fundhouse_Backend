using FH.Application.Common.Abstractions;
using System;
using System.Text.Json;
using System.Threading.Tasks;

namespace FH.Tests.Services.Services
{
    public class MockExternalServices : IExternalCurrencyApi
    {
        public async Task<string> GetCurrencySymbolsJson()
        {
            var symbol = new Domain.ValueObjects.Root();

            symbol.success = true;
            symbol.symbols.ZAR = "South African Rand";
            symbol.symbols.USD = "United States Dollar";
           
            return JsonSerializer.Serialize(symbol);
        }

        public Task<string> GetExchangeRateJson(string baseSymbol, string excSymbol, decimal amount)
        {
            throw new NotImplementedException();
        }

        public Task<string> GetRateHistoryJson(string baseSymbol, string excSymbol)
        {
            throw new NotImplementedException();
        }
    }
}
