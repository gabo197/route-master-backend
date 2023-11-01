namespace RouteMaster.API.Domain.Models
{
    public abstract class TripDetail
    {
        public int TripDetailId { get; set; }
        public int TripId { get; set; }
        public Trip Trip { get; set; } = null!;
        public int? VehicleId { get; set; }
        public int LineId { get; set; }
        public int OriginStopId { get; set; }
        public int DestinationStopId { get; set; }
        public int Order { get; set; }
        public decimal? Price { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; } = null!;
    }
}