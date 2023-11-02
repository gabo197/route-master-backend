using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class SubwayLineStopResponse : BaseResponse<SubwayLineStop>
    {
        public SubwayLineStopResponse(SubwayLineStop resource) : base(resource)
        {
        }

        public SubwayLineStopResponse(string message) : base(message)
        {
        }
    }
}
