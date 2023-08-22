using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IPassengerRepo
    {
        Task<IEnumerable<Passenger>> ListAsync();
        Task AddAsync(Passenger passenger);
        Task<Passenger?> FindById(int id);
        void Update(Passenger passenger);
        void Remove(Passenger passenger);
    }
}
