using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IBusLineService
    {
        Task<IEnumerable<BusLine>> ListAsync();
        Task<IEnumerable<BusLine>> ListByStopIdAsync(int stopId);
        Task<IEnumerable<BusLine>> ListFavoriteBusLinesByUserId(int userId);
        Task<BusLineResponse> GetByIdAsync(int id);
        Task<BusLineResponse> SaveAsync(BusLine busLine);
        Task<PassengerFavoriteBusLineResponse> SaveFavoriteBusLineForUserAsync(PassengerFavoriteBusLine passengerFavoriteBusLine);
        Task<BusLineResponse> UpdateAsync(int id, BusLine busLine);
        Task<BusLineResponse> DeleteAsync(int id);
        Task<PassengerFavoriteBusLineResponse> DeleteFavoriteBusLineForUserAsync(int userId, int busLineId);
    }
}
