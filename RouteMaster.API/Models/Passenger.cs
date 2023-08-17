namespace RouteMaster.API.Models
{
    public class Passenger : User
    {
        public int PaymentMethodId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? LastName2 { get; set; }
        public string? PhoneNumber { get; set; }
        //public ICollection<Trip> Trips { get; set; }
        //public ICollection<Transaction> Transactions { get; set; }
    }
}
