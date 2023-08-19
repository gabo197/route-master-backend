using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class ProvinceRepo : BaseRepo, IProvinceRepo
    {
        public ProvinceRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Province>> ListAsync()
        {
            return await _context.Provinces
                .Include(p => p.Department)
                .ThenInclude(d => d.Country)
                .ToListAsync();
        }
    }
}
