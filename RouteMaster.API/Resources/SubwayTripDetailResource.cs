namespace RouteMaster.API.Resources
{
    public class SubwayTripDetailResource : TripDetailResource
    {
        public SubwayResource? Subway { get; set; }
        public SubwayLineResource SubwayLine { get; set; } = null!;
        public SubwayStopResource OriginSubwayStop { get; set; } = null!;
        public SubwayStopResource DestinationSubwayStop { get; set; } = null!;
    }
}