namespace RouteMaster.API.Resources
{
    public class BusLineResource : LineResource
    {
        public ICollection<BusStopResource> BusStops { get; set; } = null!;
    }
}
