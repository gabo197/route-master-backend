namespace RouteMaster.API.Domain.Models
{
    public class SubwayLineStop : LineStop
    {
        public SubwayLine SubwayLine { get; set; } = null!;
        public SubwayStop SubwayStop { get; set; } = null!;
    }
}
