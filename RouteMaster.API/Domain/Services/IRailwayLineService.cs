using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IRailwayLineService
    {
        Task<IEnumerable<RailwayLine>> ListAsync();
        Task<RailwayLineResponse> GetByIdAsync(int id);
        Task<RailwayLineResponse> SaveAsync(RailwayLine railwayLine);
        Task<RailwayLineResponse> UpdateAsync(int id, RailwayLine railwayLine);
        Task<RailwayLineResponse> DeleteAsync(int id);
    }
}
