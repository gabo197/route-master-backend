using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class RatingResponse : BaseResponse<Rating>
    {
        public RatingResponse(Rating resource) : base(resource)
        {
        }

        public RatingResponse(string message) : base(message)
        {
        }
    }
}