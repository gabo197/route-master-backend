using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class TripDetailRepo : BaseRepo, ITripDetailRepo
    {
        public TripDetailRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(TripDetail tripDetail)
        {
            await _context.TripDetails.AddAsync(tripDetail);
        }

        public async Task<TripDetail?> FindById(int tripDetailId)
        {
            return await _context.TripDetails.FindAsync(tripDetailId);
        }

        public void Update(TripDetail tripDetail)
        {
            _context.TripDetails.Update(tripDetail);
        }
    }
}
