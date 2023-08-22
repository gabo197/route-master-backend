using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Resources
{
    public class PassengerResource : AccountResource
    {
        public int PaymentMethodId { get; set; }
        public AddressResource Address { get; set; } = null!;
        public AuditLogResource AuditLog { get; set; } = null!;
    }
}
