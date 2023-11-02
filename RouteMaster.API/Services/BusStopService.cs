using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;

namespace RouteMaster.API.Services
{
    public class BusStopService : IBusStopService
    {
        private readonly IBusStopRepo _busStopRepo;

        public BusStopService(IBusStopRepo busStopRepo)
        {
            _busStopRepo = busStopRepo;
        }

        public async Task<IEnumerable<BusStop>> ListAsync()
        {
            return await _busStopRepo.ListAsync();
        }
    }
}