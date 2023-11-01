namespace RouteMaster.API.Domain.Models
{
    public class SubwayStop : Stop
    {
        public ICollection<SubwayLine> SubwayLines { get; set; } = null!;
        public ICollection<SubwayLineStop> SubwayLineStops { get; set; } = null!;
    }
}
