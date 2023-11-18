using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class PaymentTransactionService : IPaymentTransactionService
    {
        private readonly IPaymentTransactionRepo paymentTransactionRepo;
        private readonly IUnitOfWork unitOfWork;

        public PaymentTransactionService(IPaymentTransactionRepo paymentTransactionRepo, IUnitOfWork unitOfWork)
        {
            this.paymentTransactionRepo = paymentTransactionRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<PaymentTransactionResponse> SaveAsync(PaymentTransaction transaction)
        {
            try
            {
                await paymentTransactionRepo.AddAsync(transaction);
                await unitOfWork.CompleteAsync();

                return new PaymentTransactionResponse(transaction);
            }
            catch (Exception ex)
            {
                return new PaymentTransactionResponse($"An error occurred when saving the transaction: {ex.Message}");
            }
        }

    }
}