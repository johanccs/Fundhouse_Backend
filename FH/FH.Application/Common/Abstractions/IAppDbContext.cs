using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace FH.Application.Common.Abstractions
{
    public interface IAppDbContext
    {
        public DbSet<Domain.DbModels.History> History { get; set; }
       
        Task<int> SaveChangesAsync();
    }
}
