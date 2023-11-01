namespace RouteMaster.API.Domain.Models
{
    public class RailwayStop : Stop
    {
        public ICollection<RailwayLine> RailwayLines { get; set; } = null!;
        public ICollection<RailwayLineStop> RailwayLineStops { get; set; } = null!;
    }
}
