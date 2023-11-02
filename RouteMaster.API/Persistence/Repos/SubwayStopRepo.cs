using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class SubwayStopRepo : BaseRepo, ISubwayStopRepo
    {
        public SubwayStopRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<SubwayStop>> ListAsync()
        {
            return await _context.SubwayStops.ToListAsync();
        }
    }
}