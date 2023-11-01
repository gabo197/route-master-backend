namespace RouteMaster.API.Domain.Models
{
    public class RailwayLine : Line
    {

        public ICollection<RailwayStop> RailwayStops { get; set; } = null!;
        public ICollection<RailwayLineStop> RailwayLineStops { get; set; } = null!;
        public ICollection<Railway> Railways { get; set; } = null!;
    }
}
