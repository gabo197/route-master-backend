using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface ITripService
    {
        Task<IEnumerable<Trip>> GetByUserId(int userId);
        Task<TripResponse> SaveAsync(Trip trip);
        Task<TripResponse> UpdateAsync(int tripId, Trip trip);
    }
}
