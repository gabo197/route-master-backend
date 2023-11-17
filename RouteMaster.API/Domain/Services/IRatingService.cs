using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IRatingService
    {
        Task<RatingResponse> SaveAsync(Rating rating);
    }
}