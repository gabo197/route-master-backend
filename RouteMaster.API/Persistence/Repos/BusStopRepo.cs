using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class BusStopRepo : BaseRepo, IBusStopRepo
    {
        public BusStopRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<BusStop>> ListAsync()
        {
            return await _context.BusStops.ToListAsync();
        }
    }
}