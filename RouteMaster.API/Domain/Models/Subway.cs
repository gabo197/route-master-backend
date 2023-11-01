namespace RouteMaster.API.Domain.Models
{
    public class Subway : Vehicle
    {
        public SubwayDriver? SubwayDriver { get; set; }
        public SubwayLine SubwayLine { get; set; } = null!;
    }
}
