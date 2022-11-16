using FH.Application.Common.Abstractions;
using FH.Domain.DbModels;
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

        public DbSet<History> History { get; set; }
        public DbSet<QuoteEntity> SpotRates { get; set; }
       
        public async Task<int>SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
    }
}
