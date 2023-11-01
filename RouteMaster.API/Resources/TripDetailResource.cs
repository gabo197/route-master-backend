using System.Text.Json.Serialization;

namespace RouteMaster.API.Resources
{
    public abstract class TripDetailResource
    {
        public int TripDetailId { get; set; }
        public int TripId { get; set; }
        [JsonIgnore]
        public TripResource Trip { get; set; } = null!;
        public int? VehicleId { get; set; }
        public int LineId { get; set; }
        public int OriginStopId { get; set; }
        public int DestinationStopId { get; set; }
        public int Order { get; set; }
        public decimal? Price { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleTypeResource VehicleType { get; set; } = null!;
    }
}
