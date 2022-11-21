using System.Threading.Tasks;

namespace FH.Application.Common.Abstractions
{
    public interface IHistoryService
    {
        Task<Domain.Entities.HistoryEntity> GetHistory(string baseCur, string excCur);
    }
}
