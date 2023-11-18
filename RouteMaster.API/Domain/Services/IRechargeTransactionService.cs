using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IRechargeTransactionService
    {
        Task<RechargeTransactionResponse> SaveAsync(RechargeTransaction rechargeTransaction);
    }
}