using System;
using System.Threading.Tasks;

namespace FH.Application.Common.Abstractions
{
    public interface IExternalCurrencyApi
    {
        Task<string> GetCurrencySymbolsJson();

        Task<string> GetExchangeRateJson(string baseSymbol, string excSymbol, decimal amount);

        Task<string> GetRateHistoryJson(string baseSymbol, string excSymbol);
    }
}
