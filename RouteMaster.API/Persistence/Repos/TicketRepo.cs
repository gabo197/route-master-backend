using Microsoft.EntityFrameworkCore;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Contexts;
using RouteMaster.API.Domain.Persistence.Repos;

namespace RouteMaster.API.Persistence.Repos
{
    public class TicketRepo : BaseRepo, ITicketRepo
    {
        public TicketRepo(RouteMasterContext context) : base(context)
        {
        }
        public async Task AddAsync(Ticket ticket)
        {
            await _context.Tickets.AddAsync(ticket);
        }

        public async Task<Ticket?> FindById(int id)
        {
            return await _context.Tickets
                .Include(p => p.Transaction)
                .Include(p => p.Passenger)
                .FirstOrDefaultAsync(p => p.TicketId == id);
        }

        public async Task<IEnumerable<Ticket>> ListAsync()
        {
            return await _context.Tickets
                .Include(p => p.Transaction)
                .Include(p => p.Passenger)
                .ToListAsync();
        }

        public void UpdateTransaction(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
        }
    }
}
