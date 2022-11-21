using FH.Application.Common.Abstractions;
using FH.External.ApiRunner;
using System;
using System.Threading.Tasks;

namespace FH.External.External
{
    public class ExternalCurrencyApi : IExternalCurrencyApi
    {
        public async Task<string> GetCurrencySymbolsJson()
        {
           return await new InternalApiRunner
               (new InternalApiOptions
                {
                    ApiKeyName = "apikey",
                    ApiKeyValue = "dpFUGV1bP2lYY4aInCKJiJoq2gMEC8HG",
                    TimeOut = 4000,
                    MaxRetryAttemps = 2,
                    PauseBetweenFailures = TimeSpan.FromSeconds(3)
               }).Run("https://api.apilayer.com/exchangerates_data/symbols"); 
        }

        public async Task<string> GetExchangeRateJson(string baseSymbol, string excSymbol, decimal amount)
        {
            return await new InternalApiRunner(new InternalApiOptions
            {
                TimeOut = 3000,
                MaxRetryAttemps = 2,
                PauseBetweenFailures = TimeSpan.FromSeconds(3)
           }).Run(
                "https://v6.exchangerate-api.com/v6/6462b1152ae0bd959418403d", $"pair/{baseSymbol}/{excSymbol}/{amount}");
        }

        public async Task<string> GetRateHistoryJson(string baseSymbol, string excSymbol)
        {
            var startDate = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd");

            return await new InternalApiRunner
              (new InternalApiOptions
              {
                  TimeOut = 4000
              }).Run("https://api.exchangeratesapi.io/v1/",
                     $"{startDate}?access_key=6462b1152ae0bd959418403d&base={baseSymbol}&symbols={excSymbol}");
        }
    }
}
