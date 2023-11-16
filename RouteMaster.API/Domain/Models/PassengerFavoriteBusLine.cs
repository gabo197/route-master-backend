namespace RouteMaster.API.Domain.Models
{
    public class PassengerFavoriteBusLine
    {
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; } = null!;
        public int BusLineId { get; set; }
        public BusLine BusLine { get; set; } = null!;
    }
}