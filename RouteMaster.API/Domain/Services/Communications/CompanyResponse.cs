using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class CompanyResponse : BaseResponse<Company>
    {
        public CompanyResponse(Company resource) : base(resource)
        {
        }

        public CompanyResponse(string message) : base(message)
        {
        }
    }
}
