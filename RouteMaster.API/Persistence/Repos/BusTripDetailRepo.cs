using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class BusTripDetailRepo : BaseRepo, IBusTripDetailRepo
    {
        public BusTripDetailRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(BusTripDetail tripDetail)
        {
            await _context.BusTripDetails.AddAsync(tripDetail);
        }

        public async Task<BusTripDetail?> FindById(int tripDetailId)
        {
            return await _context.BusTripDetails.FindAsync(tripDetailId);
        }

        public void Update(BusTripDetail tripDetail)
        {
            _context.BusTripDetails.Update(tripDetail);
        }
    }
}
