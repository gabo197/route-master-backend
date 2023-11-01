namespace RouteMaster.API.Domain.Models
{
    public abstract class LineStop
    {
        public int LineId { get; set; }
        public int StopId { get; set; }
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; } = null!;
    }
}
