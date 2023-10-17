namespace RouteMaster.API.Domain.Models
{
    public abstract class LineStop
    {
        public int LineId { get; set; }
        public Line Line { get; set; } = null!;
        public int StopId { get; set; }
        public Stop Stop { get; set; } = null!;
        public int VehicleTypeId { get; set; }
        public VehicleType VehicleType { get; set; } = null!;
    }
}
