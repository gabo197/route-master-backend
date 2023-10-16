namespace RouteMaster.API.Domain.Models
{
    public abstract class Vehicle
    {
        public int VehicleId { get; set; }
        public string PlateNumber { get; set; } = null!;
    }
}
