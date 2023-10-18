using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IBusLineService
    {
        Task<IEnumerable<BusLine>> ListAsync();
        Task<BusLineResponse> GetByIdAsync(int id);
        Task<BusLineResponse> SaveAsync(BusLine busLine);
        Task<BusLineResponse> UpdateAsync(int id, BusLine busLine);
        Task<BusLineResponse> DeleteAsync(int id);
    }
}
