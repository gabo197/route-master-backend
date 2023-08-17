using Microsoft.EntityFrameworkCore;

namespace RouteMaster.API.Data
{
    public class RouteMasterContext : DbContext
    {
        public RouteMasterContext(DbContextOptions options) : base(options)
        {
        }
    }
}
