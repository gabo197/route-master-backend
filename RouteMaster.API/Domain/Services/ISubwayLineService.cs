using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface ISubwayLineService
    {
        Task<IEnumerable<SubwayLine>> ListAsync();
        Task<SubwayLineResponse> GetByIdAsync(int id);
        Task<SubwayLineResponse> SaveAsync(SubwayLine subwayLine);
        Task<SubwayLineResponse> UpdateAsync(int id, SubwayLine subwayLine);
        Task<SubwayLineResponse> DeleteAsync(int id);
    }
}
