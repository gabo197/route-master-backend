using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class DepartmentRepo : BaseRepo, IDepartmentRepo
    {
        public DepartmentRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Department>> ListAsync()
        {
            return await _context.Departments
                .Include(d => d.Country)
                .ToListAsync();
        }
    }
}
