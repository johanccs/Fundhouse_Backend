using FH.Application.Common.Abstractions;
using FH.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FH.Data.DBContext
{
    public class AppContext: DbContext, IAppDbContext
    {
        public AppContext(DbContextOptions options):base(options)
        {
        }

        public DbSet<HistoryEntity> History { get; set; }
        public DbSet<SpotRateEntity> SpotRates { get; set; }

        Task<int> IAppDbContext.SaveChanges()
        {
            throw new System.NotImplementedException();
        }
    }
}
