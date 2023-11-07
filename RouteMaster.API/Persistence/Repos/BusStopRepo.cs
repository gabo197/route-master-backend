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

        async Task<IEnumerable<BusStop>> IBusStopRepo.GetByBusLineIdAsync(int id)
        {
            List<int> busLineStopsIds = _context.BusLineStops.Where(x => x.LineId == id).Select(x => x.StopId).ToList();
            IEnumerable<BusStop> busStops = await _context.BusStops.Where(stop => busLineStopsIds.Contains(stop.StopId)).ToListAsync();

            return busStops;
        }
    }
}