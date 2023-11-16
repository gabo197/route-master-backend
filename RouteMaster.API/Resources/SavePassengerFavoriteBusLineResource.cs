using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SavePassengerFavoriteBusLineResource
    {
        [Required]
        public int PassengerId { get; set; }
        [Required]
        public int BusLineId { get; set; }
    }
}