namespace RouteMaster.API.Domain.Models
{
    public class Ticket
    {
        public int TicketId { get; set; }
        public int? TransactionId { get; set; }
        public int UserId { get; set; }
        public int? Number { get; set; }
        public string? CompanyName { get; set; }
        public string? BusName { get; set; }
        public DateTime CreatedOn { get; set; }
        public Transaction? Transaction { get; set; }
        public Passenger Passenger { get; set; } = null!;
    }

}
