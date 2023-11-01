namespace RouteMaster.API.Resources
{
    public class BusResource : VehicleResource
    {
        public BusDriverResource? BusDriver { get; set; }
        public BusLineResource BusLine { get; set; } = null!;
    }
}