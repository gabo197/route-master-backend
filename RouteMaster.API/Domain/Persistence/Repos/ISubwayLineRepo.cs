using RouteMaster.API.Domain.Models;
namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface ISubwayLineRepo
    {
        Task<IEnumerable<SubwayLine>> ListAsync();
        Task AddAsync(SubwayLine subwayLine);
        Task<SubwayLine?> FindByIdAsync(int id);
        void Update(SubwayLine subwayLine);
        void Remove(SubwayLine subwayLine);
    }
}
