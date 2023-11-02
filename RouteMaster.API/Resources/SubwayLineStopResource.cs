namespace RouteMaster.API.Resources
{
    public class SubwayLineStopResource : LineStopResource
    {
        public SubwayLineResource SubwayLineResource { get; set; } = null!;
        public SubwayStopResource SubwayStopResource { get; set; } = null!;
    }
}