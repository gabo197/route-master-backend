namespace RouteMaster.API.Domain.Models
{
    public class BusDriver : Driver
    {
        
        public int? BusId { get; set; }
        public Bus? Bus { get; set; }
    }
}