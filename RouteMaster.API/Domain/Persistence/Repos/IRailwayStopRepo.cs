using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IRailwayStopRepo
    {
        Task<IEnumerable<RailwayStop>> ListAsync();
    }
}