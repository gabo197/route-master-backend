using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class SubwayLineRepo : BaseRepo, ISubwayLineRepo
    {
        public SubwayLineRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task AddAsync(SubwayLine subwayLine)
        {
            await _context.SubwayLines.AddAsync(subwayLine);
        }

        public async Task<SubwayLine?> FindByIdAsync(int id)
        {
            return await _context.SubwayLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .FirstOrDefaultAsync(bl => bl.LineId == id);
        }

        public async Task<IEnumerable<SubwayLine>> ListAsync()
        {
            return await _context.SubwayLines
                .Include(bl => bl.Company)
                .Include(bl => bl.VehicleType)
                .ToListAsync();
        }

        public void Remove(SubwayLine subwayLine)
        {
            _context.SubwayLines.Remove(subwayLine);
        }

        public void Update(SubwayLine subwayLine)
        {
            _context.SubwayLines.Update(subwayLine);
        }
    }
}
