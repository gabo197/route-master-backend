using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class TransferTransactionRepo : BaseRepo, ITransferTransactionRepo
    {
        public TransferTransactionRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(TransferTransaction transaction)
        {
            await _context.TransferTransactions.AddAsync(transaction);
        }
    }
}