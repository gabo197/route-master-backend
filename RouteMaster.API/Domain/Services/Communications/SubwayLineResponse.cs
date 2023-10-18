using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class SubwayLineResponse : BaseResponse<SubwayLine>
    {
        public SubwayLineResponse(SubwayLine resource) : base(resource)
        {
        }

        public SubwayLineResponse(string message) : base(message)
        {
        }
    }
}
