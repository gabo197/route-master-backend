namespace RouteMaster.API.Domain.Models
{
    public class BusStop
    {
        public int BusStopId { get; set; }
        public string Name { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<BusLine> BusLines { get; set; } = null!;
        public ICollection<BusLineStop> BusLineStops { get; set; } = null!;
    }
}