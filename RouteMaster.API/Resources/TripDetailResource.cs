using System.Text.Json.Serialization;

namespace RouteMaster.API.Resources
{
    public class TripDetailResource
    {
        public int TripDetailId { get; set; }
        public int TripId { get; set; }
        [JsonIgnore]
        public TripResource Trip { get; set; } = null!;
        public int? VehicleId { get; set; }
        public VehicleResource? Vehicle { get; set; }
        public int LineId { get; set; }
        public LineResource Line { get; set; } = null!;
        public int OriginStopId { get; set; }
        public StopResource OriginStop { get; set; } = null!;
        public int DestinationStopId { get; set; }
        public StopResource DestinationStop { get; set; } = null!;
        public int Order { get; set; }
    }
}
