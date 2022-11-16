using FH.Application.Common.Abstractions;
using FH.Domain.DbModels;
using FH.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FH.Infrastructure.Repositories
{
    public class HistoryRepo : IHistoryRepo
    {
        #region Readonly Fields

        private readonly IAppDbContext _dbContext;

        #endregion

        #region Ctor

        public HistoryRepo(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        #endregion

        public async  Task<int> AddToHistory(string baseCur, string exchCur, DateTime date, decimal val)
        {
            try
            {
                var history = new History()
                {
                    BaseCurrency = baseCur,
                    ExchangeCurrency = exchCur,
                    Date = date,
                    Value = val
                };

                _ = await _dbContext.History.AddAsync(history);

                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<History>> GetHistoryByCurrencyCode(string baseCur, string exchCur)
        {
            return await Task.FromResult(_dbContext.History.AsNoTracking()
                    .Where(x => x.BaseCurrency == baseCur)
                    .Where(y => y.ExchangeCurrency == exchCur)
                    .OrderByDescending(p => p.Date)
                    .Take(5));
        }
    }
}
