using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IRailwayLineStopRepo
    {
        Task AddAsync(RailwayLineStop railwayLineStop);
    }
}