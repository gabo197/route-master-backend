using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IWalletRepo
    {
        Task<IEnumerable<Wallet>> ListAsync();
        Task AddAsync(Wallet wallet);
        Task<Wallet?> FindById(int id);
        Task<Wallet?> FindByIdSimple(int id);
        void Update(Wallet wallet);
        void Remove(Wallet wallet);
    }
}
