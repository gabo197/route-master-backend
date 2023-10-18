using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class BusLineResponse : BaseResponse<BusLine>
    {
        public BusLineResponse(BusLine resource) : base(resource)
        {
        }

        public BusLineResponse(string message) : base(message)
        {
        }
    }
}
