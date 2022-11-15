using FH.Application.Common.Abstractions;
using FH.Domain.Entities;
using FH.Infrastructure.Services;
using FH.Services.Contracts;
using FH.Services.Services;
using Microsoft.Extensions.DependencyInjection;

namespace FH.Api.Extensions
{
    public static class ServicesExt
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IHistoryService<HistoryEntity>, HistoryService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IQuoteService, QuoteService>();

            return services;
        }
    }
}
