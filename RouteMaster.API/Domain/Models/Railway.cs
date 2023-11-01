namespace RouteMaster.API.Domain.Models
{
    public class Railway : Vehicle
    {
        public RailwayDriver? RailwayDriver { get; set; }
        public RailwayLine RailwayLine { get; set; } = null!;
    }
}
