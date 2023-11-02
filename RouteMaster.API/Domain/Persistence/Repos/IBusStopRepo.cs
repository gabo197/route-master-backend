using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IBusStopRepo
    {
        Task<IEnumerable<BusStop>> ListAsync();
    }
}