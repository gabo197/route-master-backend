using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Settings;
using RouteMaster.API.Util;

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
                // Encrypt the balance before saving
                wallet.Balance = WalletBalanceEncryptor.Encrypt(wallet.Balance);

                await walletRepo.AddAsync(wallet);
                await unitOfWork.CompleteAsync();

                return new WalletResponse(wallet);
            }
            catch (Exception ex)
            {
                return new WalletResponse($"An error occurred while saving the wallet: {ex.Message}");
            }
        }

        public async Task<WalletResponse> UpdateAsync(int id, Wallet wallet)
        {
            var existingWallet = await walletRepo.FindById(id);

            if (existingWallet == null)
                return new WalletResponse("Wallet not found");

            try
            {
                // Encrypt the balance before updating
                existingWallet.Balance = WalletBalanceEncryptor.Encrypt(wallet.Balance);
                existingWallet.LastUpdate = wallet.LastUpdate;
                walletRepo.Update(existingWallet);
                await unitOfWork.CompleteAsync();

                return new WalletResponse(existingWallet);
            }
            catch (Exception ex)
            {
                return new WalletResponse($"An error occurred while updating the wallet: {ex.Message}");
            }
        }

        public async Task<WalletResponse> UpdateSimpleAsync(int id, Wallet wallet)
        {
            var existingWallet = await walletRepo.FindByIdSimple(id);

            if (existingWallet == null)
                return new WalletResponse("Wallet not found");

            try
            {
                existingWallet.Balance = WalletBalanceEncryptor.Encrypt(wallet.Balance);
                walletRepo.Update(existingWallet);
                await unitOfWork.CompleteAsync();

                return new WalletResponse(existingWallet);
            }
            catch (Exception ex)
            {
                return new WalletResponse($"An error occurred while updating the wallet: {ex.Message}");
            }
        }
    }
}