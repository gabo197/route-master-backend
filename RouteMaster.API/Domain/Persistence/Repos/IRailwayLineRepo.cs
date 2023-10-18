using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IRailwayLineRepo
    {
        Task<IEnumerable<RailwayLine>> ListAsync();
        Task AddAsync(RailwayLine railwayLine);
        Task<RailwayLine?> FindByIdAsync(int id);
        void Update(RailwayLine railwayLine);
        void Remove(RailwayLine railwayLine);
    }
}
