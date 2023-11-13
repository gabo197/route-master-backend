using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IWalletService
    {
        Task<IEnumerable<Wallet>> ListAsync();
        Task<WalletResponse> GetByIdAsync(int id);
        Task<WalletResponse> SaveAsync(Wallet wallet);
        Task<WalletResponse> UpdateAsync(int id, Wallet wallet);
        Task<WalletResponse> UpdateSimpleAsync(int id, Wallet wallet);
        Task<WalletResponse> DeleteAsync(int id);
    }
}