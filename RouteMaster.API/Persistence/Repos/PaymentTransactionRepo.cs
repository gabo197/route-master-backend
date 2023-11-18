using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class PaymentTransactionRepo : BaseRepo, IPaymentTransactionRepo
    {
        public PaymentTransactionRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(PaymentTransaction transaction)
        {
            await _context.PaymentTransactions.AddAsync(transaction);
        }
    }
}