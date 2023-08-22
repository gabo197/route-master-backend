using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SavePassengerResource
    {
        [Required]
        public int PaymentMethodId { get; set; }
    }
}
