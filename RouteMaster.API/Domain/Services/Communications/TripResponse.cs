using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class TripResponse : BaseResponse<Trip>
    {
        public TripResponse(Trip resource) : base(resource)
        {
        }

        public TripResponse(string message) : base(message)
        {
        }
    }
}
