using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class DepartmentResponse : BaseResponse<Department>
    {
        public DepartmentResponse(Department resource) : base(resource)
        {
        }

        public DepartmentResponse(string message) : base(message)
        {
        }
    }
}
