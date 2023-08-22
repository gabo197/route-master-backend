using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class PassengerResponse : BaseResponse<Passenger>
    {
        public PassengerResponse(Passenger resource) : base(resource)
        {
        }

        public PassengerResponse(string message) : base(message)
        {
        }
    }
}
