using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface ITicketRepo
    {
        Task<IEnumerable<Ticket>> ListAsync();
        Task AddAsync(Ticket ticket);
        Task<Ticket?> FindById(int id);
        void UpdateTransaction(Ticket ticket);
    }
}
