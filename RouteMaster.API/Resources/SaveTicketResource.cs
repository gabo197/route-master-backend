namespace RouteMaster.API.Resources
{
    public class SaveTicketResource
    {
        public int? TransactionId { get; set; }
        public int UserId { get; set; }
        public int? Number { get; set; }
        public string? CompanyName { get; set; }
        public string? BusName { get; set; }
    }
}
