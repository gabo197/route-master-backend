using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Persistence.Repos;

namespace RouteMaster.API.Services
{
    public class TicketService: ITicketService
    {
        private readonly ITicketRepo ticketRepo;
        private readonly IUnitOfWork unitOfWork;

        public TicketService(ITicketRepo ticketRepo, IUnitOfWork unitOfWork)
        {
            this.ticketRepo = ticketRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<TicketResponse> GetByIdAsync(int id)
        {
            var existingTicket = await ticketRepo.FindById(id);

            if (existingTicket == null)
                return new TicketResponse("Ticket not found");
            return new TicketResponse(existingTicket);
        }

        public async Task<IEnumerable<Ticket>> ListAsync()
        {
            return await ticketRepo.ListAsync();
        }

        public async Task<IEnumerable<Ticket>> ListByUserIdAsync(int id)
        {
            var ticketList = await ticketRepo.ListAsync();
            var userTickets = new List<Ticket>();
            foreach (var ticket in ticketList)
            {
                if (ticket.UserId == id)
                    userTickets.Add(ticket);
            }
            return userTickets;

        }

        public async Task<TicketResponse> SaveAsync(Ticket ticket)
        {
            try
            {
                await ticketRepo.AddAsync(ticket);
                await unitOfWork.CompleteAsync();

                return new TicketResponse(ticket);
            }
            catch (Exception ex)
            {
                return new TicketResponse($"An error ocurred while saving the ticket: {ex.Message}");
            }
        }

        public async Task<TicketResponse> UpdateAsync(int id, Ticket ticket)
        {
            var existingTicket = await ticketRepo.FindById(id);

            if (existingTicket == null)
                return new TicketResponse("Ticket not found");

            existingTicket.TransactionId = ticket.TransactionId;

            try
            {
                ticketRepo.UpdateTransaction(existingTicket);
                await unitOfWork.CompleteAsync();

                return new TicketResponse(existingTicket);
            }
            catch (Exception ex)
            {
                return new TicketResponse($"An error ocurred while updating the ticket: {ex.Message}");
            }
        }
    }
}
