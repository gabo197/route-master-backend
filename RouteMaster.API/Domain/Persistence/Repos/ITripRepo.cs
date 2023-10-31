using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface ITripRepo
    {
        Task<IEnumerable<Trip>> FindByUserId(int userId);
        Task AddAsync(Trip trip);
        void Update(Trip trip);
        Task<Trip?> FindById(int tripId);
    }
}
