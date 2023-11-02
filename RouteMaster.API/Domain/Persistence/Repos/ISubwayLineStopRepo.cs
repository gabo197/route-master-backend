using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface ISubwayLineStopRepo
    {
        Task AddAsync(SubwayLineStop subwayLineStop);
    }
}