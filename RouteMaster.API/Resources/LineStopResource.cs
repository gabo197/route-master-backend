namespace RouteMaster.API.Resources
{
    public class LineStopResource
    {
        public int LineId { get; set; }
        public int StopId { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleTypeResource VehicleType { get; set; } = null!;
    }
}