using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface ILineService
    {
        Task<IEnumerable<Line>> ListAsync();
    }
}
