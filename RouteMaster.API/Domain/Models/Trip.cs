namespace RouteMaster.API.Domain.Models
{
    public class Trip
    {
        public int TripId { get; set; }
        public int UserId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TotalPrice { get; set; }
        public Passenger Passenger { get; set; } = null!;
        public ICollection<BusTripDetail> BusTripDetails { get; set; } = new List<BusTripDetail>();
        public ICollection<SubwayTripDetail> SubwayTripDetails { get; set; } = new List<SubwayTripDetail>();
        public ICollection<RailwayTripDetail> RailwayTripDetails { get; set; } = new List<RailwayTripDetail>();
    }
}