using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class SubwayLineStopRepo : BaseRepo, ISubwayLineStopRepo
    {
        public SubwayLineStopRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(SubwayLineStop subwayLineStop)
        {
            await _context.SubwayLineStops.AddAsync(subwayLineStop);
        }
    }
}