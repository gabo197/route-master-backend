namespace RouteMaster.API.Domain.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public short Value { get; set; }
        public string? Comment { get; set; }
        public int PassengerId { get; set; }
        public int TripDetailId { get; set; }
        public BusTripDetail BusTripDetail { get; set; } = null!;
        public Passenger Passenger { get; set; } = null!;
    }
}