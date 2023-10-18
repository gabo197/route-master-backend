using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class RailwayLineResponse : BaseResponse<RailwayLine>
    {
        public RailwayLineResponse(RailwayLine resource) : base(resource)
        {
        }

        public RailwayLineResponse(string message) : base(message)
        {
        }
    }
}
