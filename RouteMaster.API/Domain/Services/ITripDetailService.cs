using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface ITripDetailService
    {
        Task<TripDetailResponse> SaveAsync(TripDetail tripDetail);
        Task<TripDetailResponse> UpdateAsync(int tripDetailId, TripDetail tripDetail);
    }
}
