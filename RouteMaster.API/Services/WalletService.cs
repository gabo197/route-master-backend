using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Settings;

namespace RouteMaster.API.Services
{
    public class WalletService : IWalletService
    {
        private readonly IWalletRepo walletRepo;
        private readonly IUnitOfWork unitOfWork;

        public WalletService(IWalletRepo walletRepo, IUnitOfWork unitOfWork)
        {
            this.walletRepo = walletRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<WalletResponse> DeleteAsync(int id)
        {
            var existingWallet = await walletRepo.FindById(id);

            if (existingWallet == null)
                return new WalletResponse("Wallet not found");

            try
            {
                walletRepo.Remove(existingWallet);
                await unitOfWork.CompleteAsync();

                return new WalletResponse(existingWallet);
            }
            catch (Exception ex)
            {
                return new WalletResponse($"An error ocurred while deleting the wallet: {ex.Message}");
            }
        }

        public async Task<WalletResponse> GetByIdAsync(int id)
        {
            var existingWallet = await walletRepo.FindById(id);

            if (existingWallet == null)
                return new WalletResponse("Wallet not found");
            return new WalletResponse(existingWallet);
        }

        public async Task<IEnumerable<Wallet>> ListAsync()
        {
            return await walletRepo.ListAsync();
        }

        public async Task<WalletResponse> SaveAsync(Wallet wallet)
        {
            try
            {
                await walletRepo.AddAsync(wallet);
                await unitOfWork.CompleteAsync();

                return new WalletResponse(wallet);
            }
            catch (Exception ex)
            {
                return new WalletResponse($"An error ocurred while saving the wallet: {ex.Message}");
            }
        }

        public async Task<WalletResponse> UpdateAsync(int id, Wallet wallet)
        {
            var existingWallet = await walletRepo.FindById(id);

            if (existingWallet == null)
                return new WalletResponse("Wallet not found");

            existingWallet.Balance = wallet.Balance;
            existingWallet.LastUpdate = wallet.LastUpdate;

            try
            {
                walletRepo.Update(existingWallet);
                await unitOfWork.CompleteAsync();

                return new WalletResponse(existingWallet);
            }
            catch (Exception ex)
            {
                return new WalletResponse($"An error ocurred while updating the wallet: {ex.Message}");
            }
        }
    }
}