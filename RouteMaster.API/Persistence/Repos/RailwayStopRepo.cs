using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class RailwayStopRepo : BaseRepo, IRailwayStopRepo
    {
        public RailwayStopRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<RailwayStop>> ListAsync()
        {
            return await _context.RailwayStops.ToListAsync();
        }
    }
}