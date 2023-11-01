using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SaveTripDetailResource
    {
        [Required]
        public int TripId { get; set; }
        public int? VehicleId { get; set; }
        [Required]
        public int LineId { get; set; }
        [Required]
        public int OriginStopId { get; set; }
        [Required]
        public int DestinationStopId { get; set; }
        [Required]
        public int Order { get; set; }
        public decimal? Price { get; set; }
    }
}
