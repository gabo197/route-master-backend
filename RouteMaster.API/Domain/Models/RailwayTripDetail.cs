namespace RouteMaster.API.Domain.Models
{
    public class RailwayTripDetail : TripDetail
    {
        public Railway? Railway { get; set; }
        public RailwayLine RailwayLine { get; set; } = null!;
        public RailwayStop OriginRailwayStop { get; set; } = null!;
        public RailwayStop DestinationRailwayStop { get; set; } = null!;
    }
}