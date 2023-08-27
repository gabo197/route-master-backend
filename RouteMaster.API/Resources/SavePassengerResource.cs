using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SavePassengerResource : SaveAccountResource
    {
        [Required]
        public int PaymentMethodId { get; set; }
    }
}
