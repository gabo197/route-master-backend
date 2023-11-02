using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class BusLineStopResponse : BaseResponse<BusLineStop>
    {
        public BusLineStopResponse(BusLineStop resource) : base(resource)
        {
        }

        public BusLineStopResponse(string message) : base(message)
        {
        }
    }
}
