using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class BusLineRepo : BaseRepo, IBusLineRepo
    {
        public BusLineRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(BusLine busLine)
        {
            await _context.BusLines.AddAsync(busLine);
        }

        public async Task AddFavoriteBusLineForUser(PassengerFavoriteBusLine passengerFavoriteBusLine)
        {
            await _context.PassengerFavoriteBusLines.AddAsync(passengerFavoriteBusLine);
        }

        public async Task<BusLine?> FindByIdAsync(int id)
        {
            return await _context.BusLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .FirstOrDefaultAsync(bl => bl.LineId == id);
        }

        public async Task<PassengerFavoriteBusLine?> FindFavoriteBusLineForUser(int userId, int busLineId)
        {
            return await _context.PassengerFavoriteBusLines
            .FirstOrDefaultAsync(f => f.PassengerId == userId && f.BusLineId == busLineId);
        }

        public async Task<IEnumerable<BusLine>> ListAsync()
        {
            return await _context.BusLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .ToListAsync();
        }

        public async Task<IEnumerable<BusLine>> ListByStopIdAsync(int stopId)
        {
            var linesForStop = await _context.BusLines
            .FromSqlInterpolated($@"
                SELECT l.*
                FROM Line l
                JOIN LineStop ls ON l.LineId = ls.LineId and ls.VehicleTypeId = 1
                JOIN Stop s ON ls.StopId = s.StopId and s.VehicleTypeId = 1
                WHERE l.VehicleTypeId = 1 and s.StopId = {stopId}
            ")
            .ToListAsync();

            return linesForStop;
        }

        public async Task<IEnumerable<BusLine>> ListFavoriteBusLinesByUserId(int userId)
        {
            return await _context.BusLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .Where(l => l.PassengerFavoriteBusLines.Any(f => f.PassengerId == userId))
                .ToListAsync();
        }

        public void Remove(BusLine busLine)
        {
            _context.BusLines.Remove(busLine);
        }

        public void RemoveFavoriteBusLineForUser(PassengerFavoriteBusLine passengerFavoriteBusLine)
        {
            _context.PassengerFavoriteBusLines.Remove(passengerFavoriteBusLine);
        }

        public void Update(BusLine busLine)
        {
            _context.BusLines.Update(busLine);
        }
    }
}
