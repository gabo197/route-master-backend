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
            return await _context.Passengers.FindAsync(id);
        }

        public async Task<IEnumerable<Passenger>> ListAsync()
        {
            return await _context.Passengers.ToListAsync();
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
