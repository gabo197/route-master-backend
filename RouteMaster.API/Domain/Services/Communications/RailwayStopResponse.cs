using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class RailwayStopResponse : BaseResponse<RailwayStop>
    {
        public RailwayStopResponse(RailwayStop resource) : base(resource)
        {
        }

        public RailwayStopResponse(string message) : base(message)
        {
        }
    }
}