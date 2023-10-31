namespace RouteMaster.API.Resources
{
    public class TripResource
    {
        public int TripId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public PassengerResource Passenger { get; set; } = null!;
        public ICollection<TripDetailResource> TripDetails { get; set; } = new List<TripDetailResource>();
    }
}
