using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class BusTripDetailResponse : BaseResponse<BusTripDetail>
    {
        public BusTripDetailResponse(BusTripDetail resource) : base(resource)
        {
        }

        public BusTripDetailResponse(string message) : base(message)
        {
        }
    }
}
