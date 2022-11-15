using FH.Domain.Entities;

namespace FH.Services.Contracts
{
    public interface IHistoryService<T> where T: HistoryEntity, new()
    {
    }
}
