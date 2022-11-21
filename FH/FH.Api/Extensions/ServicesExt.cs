using FH.Application.Common.Abstractions;
using FH.Data.DBContext;
using FH.External.External;
using FH.Infrastructure.Repositories;
using FH.Infrastructure.Services;
using FH.Services.Contracts;
using FH.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FH.Api.Extensions
{
    public static class ServicesExt
    {
        public static IServiceCollection RegisterServices(this IServiceCollection services)
        {
            services.AddScoped<IHistoryRepo, HistoryRepo>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IQuoteService, QuoteService>();
            services.AddScoped<IAppDbContext, AppContext>();
            services.AddScoped<IExternalCurrencyApi, ExternalCurrencyApi>();
            services.AddScoped<IHistoryService, HistoryService>();

            return services;
        }

        public static IServiceCollection RegisterDatabase(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppContext>(options =>
{
                options.UseSqlite(config.GetConnectionString("DefaultConnection"));
            });

            return services;
        }
    }
}
