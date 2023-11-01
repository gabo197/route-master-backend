namespace RouteMaster.API.Domain.Models
{
    public class BusTripDetail : TripDetail
    {
        public Bus? Bus { get; set; }
        public BusLine BusLine { get; set; } = null!;
        public BusStop OriginBusStop { get; set; } = null!;
        public BusStop DestinationBusStop { get; set; } = null!;
    }
}