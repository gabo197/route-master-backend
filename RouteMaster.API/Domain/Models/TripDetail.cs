namespace RouteMaster.API.Domain.Models
{
    public class TripDetail
    {
        public int TripDetailId { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; } = null!;
        public int? VehicleId { get; set; }
        public Vehicle? Vehicle { get; set; }
        public int LineId { get; set; }
        public Line Line { get; set; } = null!;
        public int OriginStopId { get; set; }
        public Stop OriginStop { get; set; } = null!;
        public int DestinationStopId { get; set; }
        public Stop DestinationStop { get; set; } = null!;
        public int Order { get; set; }
    }
}