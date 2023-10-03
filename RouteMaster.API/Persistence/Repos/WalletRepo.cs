using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class WalletRepo : BaseRepo, IWalletRepo
    {
        public WalletRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(Wallet wallet)
        {
            await _context.Wallets.AddAsync(wallet);
        }

        public async Task<Wallet?> FindById(int id)
        {
            return await _context.Wallets.FindAsync(id);
        }

        public async Task<IEnumerable<Wallet>> ListAsync()
        {
            return await _context.Wallets.ToListAsync();
        }

        public void Remove(Wallet wallet)
        {
            _context.Wallets.Remove(wallet);
        }

        public void Update(Wallet wallet)
        {
            _context.Wallets.Update(wallet);
        }
    }
}