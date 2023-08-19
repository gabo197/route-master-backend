using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface IDepartmentService
    {
        Task<IEnumerable<Department>> ListAsync();
    }
}
