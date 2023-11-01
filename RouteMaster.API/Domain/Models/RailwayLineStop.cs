namespace RouteMaster.API.Domain.Models
{
    public class RailwayLineStop : LineStop
    {
        public RailwayLine RailwayLine { get; set; } = null!;
        public RailwayStop RailwayStop { get; set; } = null!;
    }
}
