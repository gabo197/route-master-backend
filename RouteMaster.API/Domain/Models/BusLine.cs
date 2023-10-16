namespace RouteMaster.API.Domain.Models
{
    public class BusLine
    {
        public int BusLineId { get; set; }
        public string Code { get; set; } = null!;
        public string FirstStop { get; set; } = null!;
        public string LastStop { get; set; } = null!;
        public string? Alias { get; set; }
        public string Color { get; set; } = null!;
        public int CompanyId { get; set; }
        public int LineTypeId { get; set; }
        public Company Company { get; set; } = null!;
        public LineType LineType { get; set; } = null!;
        public ICollection<BusStop> BusStops { get; set; } = null!;
        public ICollection<BusLineStop> BusLineStops { get; set; } = null!;
        public ICollection<Bus> Buses { get; set; } = null!;
        public ICollection<TripDetail> TripDetails { get; set; } = null!;
    }
}