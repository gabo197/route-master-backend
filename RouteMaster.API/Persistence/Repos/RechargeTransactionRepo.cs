using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class RechargeTransactionRepo : BaseRepo, IRechargeTransactionRepo
    {
        public RechargeTransactionRepo(RouteMasterContext context) : base(context)
        {
        }
        
        public async Task AddAsync(RechargeTransaction transaction)
        {
            await _context.RechargeTransactions.AddAsync(transaction);
        }
    }
}