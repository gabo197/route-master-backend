using System.Text.Json.Serialization;

namespace RouteMaster.API.Resources
{
    public class RatingResource
    {
        public int RatingId { get; set; }
        public short Value { get; set; }
        public string? Comment { get; set; }
        public int PassengerId { get; set; }
        public int TripDetailId { get; set; }
        [JsonIgnore]
        public BusTripDetailResource BusTripDetail { get; set; } = null!;
        [JsonIgnore]
        public PassengerResource Passenger { get; set; } = null!;
    }
}