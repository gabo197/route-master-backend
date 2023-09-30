using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

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
            return await _context.Passengers
                .Include(p => p.PaymentMethod)
                .Include(p => p.Address)
                .Include(p => p.AuditLog)
                .Include(p => p.User)
                .Include(p => p.Wallet)
                .FirstOrDefaultAsync(p => p.UserId == id);
        }

        public async Task<IEnumerable<Passenger>> ListAsync()
        {
            return await _context.Passengers
                .Include(p => p.PaymentMethod)
                .Include(p => p.Address)
                .Include(p => p.AuditLog)
                .Include(p => p.User)
                .Include(p => p.Wallet)
                .ToListAsync();
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
