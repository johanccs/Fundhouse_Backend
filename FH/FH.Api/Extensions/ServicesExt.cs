using FH.Domain.Entities;
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

            return services;
        }
    }
}
