using FH.Domain.DbModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FH.Services.Contracts
{
    public interface IHistoryRepo
    {
        Task<IEnumerable<History>> GetHistoryByCurrencyCode(string baseCur, string exchCur);
        
        Task<int> AddToHistory(string baseCur, string exchCur, DateTime date, decimal val);
    }
}
