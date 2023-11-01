using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IBusTripDetailService
    {
        Task<BusTripDetailResponse> SaveAsync(BusTripDetail tripDetail);
        Task<BusTripDetailResponse> UpdateAsync(int tripDetailId, BusTripDetail tripDetail);
    }
}
