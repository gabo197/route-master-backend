using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface ITicketService
    {
        Task<IEnumerable<Ticket>> ListAsync();
        Task<TicketResponse> GetByIdAsync(int id);
        Task<TicketResponse> SaveAsync(Ticket ticket);
        Task<IEnumerable<Ticket>> ListByUserIdAsync(int id);
        Task<TicketResponse> UpdateAsync(int id, Ticket ticket);

    }
}
