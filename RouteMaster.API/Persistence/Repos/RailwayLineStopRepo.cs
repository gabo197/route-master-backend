using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class RailwayLineStopRepo : BaseRepo, IRailwayLineStopRepo
    {
        public RailwayLineStopRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(RailwayLineStop railwayLineStop)
        {
            await _context.RailwayLineStops.AddAsync(railwayLineStop);
        }
    }
}