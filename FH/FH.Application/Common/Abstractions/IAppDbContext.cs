using FH.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FH.Application.Common.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<HistoryEntity> History { get; set; }
        public DbSet<SpotRateEntity> SpotRates { get; set; }

        Task<int> SaveChanges();
    }
}
