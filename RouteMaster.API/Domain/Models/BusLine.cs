namespace RouteMaster.API.Domain.Models
{
    public class BusLine : Line
    {
        public ICollection<BusStop> BusStops { get; set; } = null!;
        public ICollection<BusLineStop> BusLineStops { get; set; } = null!;
        public ICollection<Bus> Buses { get; set; } = null!;
    }
}