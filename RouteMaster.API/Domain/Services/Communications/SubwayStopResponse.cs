using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class SubwayStopResponse : BaseResponse<SubwayStop>
    {
        public SubwayStopResponse(SubwayStop resource) : base(resource)
        {
        }

        public SubwayStopResponse(string message) : base(message)
        {
        }
    }
}