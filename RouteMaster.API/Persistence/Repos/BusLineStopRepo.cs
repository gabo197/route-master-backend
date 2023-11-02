using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class BusLineStopRepo : BaseRepo, IBusLineStopRepo
    {
        public BusLineStopRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(BusLineStop busLineStop)
        {
            await _context.BusLineStops.AddAsync(busLineStop);
        }
    }
}