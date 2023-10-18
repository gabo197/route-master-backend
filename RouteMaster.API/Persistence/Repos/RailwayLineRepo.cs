using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class RailwayLineRepo : BaseRepo, IRailwayLineRepo
    {
        public RailwayLineRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(RailwayLine railwayLine)
        {
            await _context.RailwayLines.AddAsync(railwayLine);
        }

        public async Task<RailwayLine?> FindByIdAsync(int id)
        {
            return await _context.RailwayLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .FirstOrDefaultAsync(bl => bl.LineId == id);
        }

        public async Task<IEnumerable<RailwayLine>> ListAsync()
        {
            return await _context.RailwayLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .ToListAsync();
        }

        public void Remove(RailwayLine railwayLine)
        {
            _context.RailwayLines.Remove(railwayLine);
        }

        public void Update(RailwayLine railwayLine)
        {
            _context.RailwayLines.Update(railwayLine);
        }
    }
}
