using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SaveRatingResource
    {
        [Required]
        public short Value { get; set; }
        public string? Comment { get; set; }
        [Required]
        public int PassengerId { get; set; }
        [Required]
        public int TripDetailId { get; set; }
    }
}