using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class TripDetailResponse : BaseResponse<TripDetail>
    {
        public TripDetailResponse(TripDetail resource) : base(resource)
        {
        }

        public TripDetailResponse(string message) : base(message)
        {
        }
    }
}
