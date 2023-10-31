namespace RouteMaster.API.Resources
{
    public abstract class StopResource
    {
        public int StopId { get; set; }
        public int VehicleTypeId { get; set; }
        public string Name { get; set; } = null!;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public VehicleTypeResource VehicleType { get; set; } = null!;
    }
}
