using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class RailwayStopService : IRailwayStopService
    {
        private readonly IRailwayStopRepo _railwayStopRepo;

        public RailwayStopService(IRailwayStopRepo railwayStopRepo)
        {
            _railwayStopRepo = railwayStopRepo;
        }

        public async Task<IEnumerable<RailwayStop>> ListAsync()
        {
            return await _railwayStopRepo.ListAsync();
        }
    }
}