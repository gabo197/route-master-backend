using RouteMaster.API.Domain.Persistence.Contexts;
using System;

namespace RouteMaster.API.Persistence.Repos
{
    public class BaseRepo
    {
        protected readonly RouteMasterContext _context;

        public BaseRepo(RouteMasterContext context)
        {
            _context = context;
        }
    }
}
