namespace RouteMaster.API.Resources
{
    public abstract class VehicleResource
    {
        public int VehicleId { get; set; }
        public int VehicleTypeId { get; set; }
        public string PlateNumber { get; set; } = null!;
        public VehicleTypeResource VehicleType { get; set; } = null!;
        public DriverResource? Driver { get; set; }
        public int LineId { get; set; }
        public LineResource Line { get; set; } = null!;
    }
}
