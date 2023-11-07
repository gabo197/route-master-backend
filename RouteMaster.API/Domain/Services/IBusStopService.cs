using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface IBusStopService
    {
        Task<IEnumerable<BusStop>> ListAsync();
        Task<IEnumerable<BusStop>> GetByBusLineIdAsync(int id);
    }
}