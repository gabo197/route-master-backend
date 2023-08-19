using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class DistrictResponse : BaseResponse<District>
    {
        public DistrictResponse(District resource) : base(resource)
        {
        }

        public DistrictResponse(string message) : base(message)
        {
        }
    }
}
