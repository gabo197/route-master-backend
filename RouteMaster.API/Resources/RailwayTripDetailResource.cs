namespace RouteMaster.API.Resources
{
    public class RailwayTripDetailResource : TripDetailResource
    {
        public RailwayResource? Railway { get; set; }
        public RailwayLineResource RailwayLine { get; set; } = null!;
        public RailwayStopResource OriginRailwayStop { get; set; } = null!;
        public RailwayStopResource DestinationRailwayStop { get; set; } = null!;
    }
}