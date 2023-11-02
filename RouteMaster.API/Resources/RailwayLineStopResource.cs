namespace RouteMaster.API.Resources
{
    public class RailwayLineStopResource : LineStopResource
    {
        public RailwayLineResource RailwayLineResource { get; set; } = null!;
        public RailwayStopResource RailwayStopResource { get; set; } = null!;
    }
}