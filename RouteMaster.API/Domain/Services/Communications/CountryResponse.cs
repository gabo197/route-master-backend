using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class CountryResponse : BaseResponse<Country>
    {
        public CountryResponse(Country resource) : base(resource)
        {
        }

        public CountryResponse(string message) : base(message)
        {
        }
    }
}
