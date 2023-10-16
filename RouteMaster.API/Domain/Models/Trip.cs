namespace RouteMaster.API.Domain.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public decimal TotalPrice { get; set; }
        public Passenger Passenger { get; set; } = null!;
        public ICollection<TripDetail> TripDetails { get; set; } = null!;
    }
}