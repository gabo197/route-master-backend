using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class RailwayLineStopResponse : BaseResponse<RailwayLineStop>
    {
        public RailwayLineStopResponse(RailwayLineStop resource) : base(resource)
        {
        }

        public RailwayLineStopResponse(string message) : base(message)
        {
        }
    }
}