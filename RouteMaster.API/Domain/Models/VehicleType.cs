namespace RouteMaster.API.Domain.Models
{
    public class VehicleType
    {
        public int VehicleTypeId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Vehicle> Vehicles { get; set; } = null!;
        public ICollection<Driver> Drivers { get; set; } = null!;
        public ICollection<Stop> Stops { get; set; } = null!;
        public ICollection<Line> Lines { get; set; } = null!;
        public ICollection<LineStop> LineStops { get; set; } = null!;
    }
}