using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class PassengerFavoriteBusLineResponse : BaseResponse<PassengerFavoriteBusLine>
    {
        public PassengerFavoriteBusLineResponse(PassengerFavoriteBusLine resource) : base(resource)
        {
        }

        public PassengerFavoriteBusLineResponse(string message) : base(message)
        {
        }
    }
}