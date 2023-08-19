using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> ListAsync();
    }
}
