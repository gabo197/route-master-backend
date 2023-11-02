using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class SubwayStopService : ISubwayStopService
    {
        private readonly ISubwayStopRepo _subwayStopRepo;

        public SubwayStopService(ISubwayStopRepo subwayStopRepo)
        {
            _subwayStopRepo = subwayStopRepo;
        }

        public async Task<IEnumerable<SubwayStop>> ListAsync()
        {
            return await _subwayStopRepo.ListAsync();
        }
    }
}