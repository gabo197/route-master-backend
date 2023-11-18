using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface ITransactionService
    {
        Task<IEnumerable<Transaction>> ListByWalletIdAsync(int walletId);
    }
}