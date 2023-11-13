using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Util;

namespace RouteMaster.API.Persistence.Repos
{
    public class PassengerRepo : BaseRepo, IPassengerRepo
    {
        public PassengerRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(Passenger passenger)
        {
            await _context.Passengers.AddAsync(passenger);
        }

        public async Task<Passenger?> FindById(int id)
        {
            var passenger = await _context.Passengers
                .Include(p => p.PaymentMethod)
                .Include(p => p.Address)
                .Include(p => p.AuditLog)
                .Include(p => p.User)
                .Include(p => p.Wallet)
                .FirstOrDefaultAsync(p => p.UserId == id);
            passenger!.Wallet.Balance = WalletBalanceEncryptor.Decrypt(passenger.Wallet.Balance);
            return passenger;
        }

        public async Task<IEnumerable<Passenger>> ListAsync()
        {
            var passengers = await _context.Passengers
                .Include(p => p.PaymentMethod)
                .Include(p => p.Address)
                .Include(p => p.AuditLog)
                .Include(p => p.User)
                .Include(p => p.Wallet)
                .ToListAsync();
            foreach (var passenger in passengers)
            {
                if (passenger.Wallet != null)
                    passenger.Wallet.Balance = WalletBalanceEncryptor.Decrypt(passenger.Wallet.Balance);
            }
            return passengers;
        }

        public void Remove(Passenger passenger)
        {
            _context.Passengers.Remove(passenger);
        }

        public void Update(Passenger passenger)
        {
            _context.Passengers.Update(passenger);
        }
    }
}
