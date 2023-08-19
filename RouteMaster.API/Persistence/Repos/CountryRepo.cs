using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class CountryRepo : BaseRepo, ICountryRepo
    {
        public CountryRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Country>> ListAsync()
        {
            return await _context.Countries.ToListAsync();
        }
    }
}
