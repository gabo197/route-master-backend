using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IPassengerService
    {
        Task<IEnumerable<Passenger>> ListAsync();
        Task<PassengerResponse> GetByIdAsync(int id);
        Task<PassengerResponse> SaveAsync(Passenger passenger);
        Task<PassengerResponse> UpdateAsync(int id, Passenger passenger);
        Task<PassengerResponse> DeleteAsync(int id);
    }
}
