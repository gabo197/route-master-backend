using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class TransactionRepo : BaseRepo, ITransactionRepo
    {
        public TransactionRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Transaction>> ListByWalletIdAsync(int walletId)
        {
            return await _context.Transactions
                .Where(t => t.WalletId == walletId || t.RecipientWalletId == walletId)
                .ToListAsync();
        }
    }
}