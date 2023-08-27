namespace RouteMaster.API.Domain.Models
{
    public class PaymentMethod
    {
        public int PaymentMethodId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Passenger> Passengers { get; set; } = null!;
    }
}
