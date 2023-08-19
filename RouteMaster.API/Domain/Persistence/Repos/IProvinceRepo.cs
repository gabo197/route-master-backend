using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IProvinceRepo
    {
        Task<IEnumerable<Province>> ListAsync();
    }
}
