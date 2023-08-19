using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;
using System;

namespace RouteMaster.API.Persistence.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly RouteMasterContext _context;
        public UnitOfWork(RouteMasterContext context)
        {
            _context = context;
        }
        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
