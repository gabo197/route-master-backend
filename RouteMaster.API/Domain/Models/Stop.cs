namespace RouteMaster.API.Domain.Models
{
    public abstract class Stop
    {
        public int StopId { get; set; }
        public int VehicleTypeId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public VehicleType VehicleType { get; set; } = null!;
    }
}