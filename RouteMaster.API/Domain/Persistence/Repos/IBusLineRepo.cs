using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IBusLineRepo
    {
        Task<IEnumerable<BusLine>> ListAsync();
        Task<IEnumerable<BusLine>> ListByStopIdAsync(int stopId);
        Task<IEnumerable<BusLine>> ListFavoriteBusLinesByUserId(int userId);
        Task AddAsync(BusLine busLine);
        Task AddFavoriteBusLineForUser(PassengerFavoriteBusLine passengerFavoriteBusLine);
        void RemoveFavoriteBusLineForUser(PassengerFavoriteBusLine passengerFavoriteBusLine);
        Task<BusLine?> FindByIdAsync(int id);
        Task<PassengerFavoriteBusLine?> FindFavoriteBusLineForUser(int userId, int busLineId);
        void Update(BusLine busLine);
        void Remove(BusLine busLine);
    }
}
