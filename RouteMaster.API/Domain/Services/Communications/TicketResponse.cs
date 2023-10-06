using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class TicketResponse:BaseResponse<Ticket>
    {
        public TicketResponse(Ticket resource) : base(resource)
        {
        }

        public TicketResponse(string message) : base(message)
        {
        }
    }
}
