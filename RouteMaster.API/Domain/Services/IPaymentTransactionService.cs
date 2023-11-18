using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IPaymentTransactionService
    {
        Task<PaymentTransactionResponse> SaveAsync(PaymentTransaction paymentTransaction);
    }
}