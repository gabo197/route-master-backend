using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface IRailwayStopService
    {
        Task<IEnumerable<RailwayStop>> ListAsync();
    }
}