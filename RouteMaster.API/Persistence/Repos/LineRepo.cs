using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class LineRepo : BaseRepo, ILineRepo
    {
        public LineRepo(RouteMasterContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Line>> ListAsync()
        {
            return await _context.Lines.ToListAsync();
        }
    }
}
