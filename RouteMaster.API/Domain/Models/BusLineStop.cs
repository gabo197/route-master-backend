namespace RouteMaster.API.Domain.Models
{
    public class BusLineStop
    {
        public int BusLineId { get; set; }
        public BusLine BusLine { get; set; } = null!;
        public int BusStopId { get; set; }
        public BusStop BusStop { get; set; } = null!;
    }
}