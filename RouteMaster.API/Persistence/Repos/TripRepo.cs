using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class TripRepo : BaseRepo, ITripRepo
    {
        public TripRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(Trip trip)
        {
            await _context.Trips.AddAsync(trip);
        }

        public async Task<Trip?> FindById(int tripId)
        {
            return await _context.Trips.FindAsync(tripId);
        }

        public async Task<IEnumerable<Trip>> FindByUserId(int userId)
        {
            return await _context.Trips
                .Where(t => t.UserId == userId)
                .Include(t => t.TripDetails)
                //    .ThenInclude(td => td.Line)
                //.Include(t => t.TripDetails)
                //    .ThenInclude(td => td.Vehicle)
                //.Include(t => t.TripDetails)
                //    .ThenInclude(td => td.OriginStop)
                //.Include(t => t.TripDetails)
                //    .ThenInclude(td => td.DestinationStop)
                .ToListAsync();
        }

        public void Update(Trip trip)
        {
            _context.Trips.Update(trip);
        }
    }
}
