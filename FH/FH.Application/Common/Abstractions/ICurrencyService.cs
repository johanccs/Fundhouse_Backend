using FH.Domain.ValueObjects;
using System.Threading.Tasks;

namespace FH.Services.Contracts
{
    //Retrieve the different currencies

    public interface ICurrencyService
    {
        Task<Symbols> GetCurrenciesAsync();
    }
}
