namespace RouteMaster.API.Domain.Models
{
    public class Bus
    {
        public int BusId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public BusDriver? BusDriver { get; set; }
        public int BusLineId { get; set; }
        public BusLine BusLine { get; set; } = null!;
        public ICollection<TripDetail> TripDetails { get; set; } = null!;
    }
}