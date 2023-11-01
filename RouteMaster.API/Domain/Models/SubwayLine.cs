namespace RouteMaster.API.Domain.Models
{
    public class SubwayLine : Line
    {
        public ICollection<SubwayStop> SubwayStops { get; set; } = null!;
        public ICollection<SubwayLineStop> SubwayLineStops { get; set; } = null!;
        public ICollection<Subway> Subways { get; set; } = null!;
    }
}
