using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class TransferTransactionService : ITransferTransactionService
    {
        private readonly ITransferTransactionRepo transferTransactionRepo;
        private readonly IUnitOfWork unitOfWork;

        public TransferTransactionService(ITransferTransactionRepo transferTransactionRepo, IUnitOfWork unitOfWork)
        {
            this.transferTransactionRepo = transferTransactionRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<TransferTransactionResponse> SaveAsync(TransferTransaction transferTransaction)
        {
            try
            {
                await transferTransactionRepo.AddAsync(transferTransaction);
                await unitOfWork.CompleteAsync();

                return new TransferTransactionResponse(transferTransaction);
            }
            catch (Exception ex)
            {
                return new TransferTransactionResponse($"An error occurred when saving the transaction: {ex.Message}");
            }
        }
    }
}