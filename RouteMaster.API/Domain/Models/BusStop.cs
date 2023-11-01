namespace RouteMaster.API.Domain.Models
{
    public class BusStop : Stop
    {

        public ICollection<BusLine> BusLines { get; set; } = null!;
        public ICollection<BusLineStop> BusLineStops { get; set; } = null!;
    }
}