namespace RouteMaster.API.Domain.Models
{
    public class TripDetail
    {
        public int TripDetailId { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; } = null!;
        public int? BusId { get; set; }
        public Bus? Bus { get; set; }
        public int BusLineId { get; set; }
        public BusLine BusLine { get; set; } = null!;
        public int OriginBusStopId { get; set; }
        public BusStop OriginBusStop { get; set; } = null!;
        public int DestinationBusStopId { get; set; }
        public BusStop DestinationBusStop { get; set; } = null!;
        public int Order { get; set; }
    }
}