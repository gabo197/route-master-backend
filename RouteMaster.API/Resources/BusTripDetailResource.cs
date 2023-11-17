namespace RouteMaster.API.Resources
{
    public class BusTripDetailResource : TripDetailResource
    {
        public BusResource? Bus { get; set; }
        public RatingResource? Rating { get; set; }
        public BusLineResource BusLine { get; set; } = null!;
        public BusStopResource OriginBusStop { get; set; } = null!;
        public BusStopResource DestinationBusStop { get; set; } = null!;
    }
}