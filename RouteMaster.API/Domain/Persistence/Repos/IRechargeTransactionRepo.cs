using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IRechargeTransactionRepo
    {
        Task AddAsync(RechargeTransaction transaction);
    }
}