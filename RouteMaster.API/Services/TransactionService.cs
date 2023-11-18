using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepo transactionRepo;

        public TransactionService(ITransactionRepo transactionRepo)
        {
            this.transactionRepo = transactionRepo;
        }

        public async Task<IEnumerable<Transaction>> ListByWalletIdAsync(int walletId)
        {
            return await transactionRepo.ListByWalletIdAsync(walletId);
        }
    }
}