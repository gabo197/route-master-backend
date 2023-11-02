namespace RouteMaster.API.Resources
{
    public class BusLineStopResource : LineStopResource
    {
        public BusLineResource BusLineResource { get; set; } = null!;
        public BusStopResource BusStopResource { get; set; } = null!;
    }
}