using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services
{
    public interface ISubwayStopService
    {
        Task<IEnumerable<SubwayStop>> ListAsync();
    }
}