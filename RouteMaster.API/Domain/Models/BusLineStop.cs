namespace RouteMaster.API.Domain.Models
{
    public class BusLineStop : LineStop
    {
        public BusLine BusLine { get; set; } = null!;
        public BusStop BusStop { get; set; } = null!;
    }
}