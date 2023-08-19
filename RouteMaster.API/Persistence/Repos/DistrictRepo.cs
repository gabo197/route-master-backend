using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class DistrictRepo : BaseRepo, IDistrictRepo
    {
        public DistrictRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<District>> ListAsync()
        {
            return await _context.Districts
                .Include(d => d.Province)
                .ThenInclude(p => p.Department)
                .ThenInclude(d => d.Country)
                .ToListAsync();
        }
    }
}
