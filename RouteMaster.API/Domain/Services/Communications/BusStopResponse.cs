using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class BusStopResponse : BaseResponse<BusStop>
    {
        public BusStopResponse(BusStop resource) : base(resource)
        {
        }

        public BusStopResponse(string message) : base(message)
        {
        }
    }
}