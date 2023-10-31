namespace RouteMaster.API.Resources
{
    public class SaveTripDetailResource
    {
        public int TripId { get; set; }
        public int? VehicleId { get; set; }
        public int LineId { get; set; }
        public int OriginStopId { get; set; }
        public int DestinationStopId { get; set; }
        public int Order { get; set; }
    }
}
