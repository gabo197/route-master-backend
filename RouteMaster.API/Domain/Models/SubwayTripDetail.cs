namespace RouteMaster.API.Domain.Models
{
    public class SubwayTripDetail : TripDetail
    {
        public Subway? Subway { get; set; }
        public SubwayLine SubwayLine { get; set; } = null!;
        public SubwayStop OriginSubwayStop { get; set; } = null!;
        public SubwayStop DestinationSubwayStop { get; set; } = null!;
    }
}