using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class RechargeTransactionService : IRechargeTransactionService
    {
        private readonly IRechargeTransactionRepo rechargeTransactionRepo;
        private readonly IUnitOfWork unitOfWork;

        public RechargeTransactionService(IRechargeTransactionRepo rechargeTransactionRepo, IUnitOfWork unitOfWork)
        {
            this.rechargeTransactionRepo = rechargeTransactionRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<RechargeTransactionResponse> SaveAsync(RechargeTransaction transaction)
        {
            try
            {
                await rechargeTransactionRepo.AddAsync(transaction);
                await unitOfWork.CompleteAsync();

                return new RechargeTransactionResponse(transaction);
            }
            catch (Exception ex)
            {
                return new RechargeTransactionResponse($"An error occurred when saving the transaction: {ex.Message}");
            }
        }
    }
}