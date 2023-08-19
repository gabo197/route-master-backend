using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface IProvinceService
    {
        Task<IEnumerable<Province>> ListAsync();
    }
}
