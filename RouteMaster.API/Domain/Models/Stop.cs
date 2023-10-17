namespace RouteMaster.API.Domain.Models
{
    public abstract class Stop
    {
        public int StopId { get; set; }
        public string Name { get; set; } = null!;
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}