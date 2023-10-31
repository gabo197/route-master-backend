using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SaveTripResource
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public decimal? TotalPrice { get; set; }
    }
}
