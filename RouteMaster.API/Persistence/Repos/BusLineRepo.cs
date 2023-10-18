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

        public async Task<BusLine?> FindByIdAsync(int id)
        {
            return await _context.BusLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .FirstOrDefaultAsync(bl => bl.LineId == id);
        }

        public async Task<IEnumerable<BusLine>> ListAsync()
        {
            return await _context.BusLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .ToListAsync();
        }

        public void Remove(BusLine busLine)
        {
            _context.BusLines.Remove(busLine);
        }

        public void Update(BusLine busLine)
        {
            _context.BusLines.Update(busLine);
        }
    }
}
