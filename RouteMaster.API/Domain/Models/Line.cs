namespace RouteMaster.API.Domain.Models
{
    public abstract class Line
    {
        public int LineId { get; set; }
        public string Code { get; set; } = null!;
        public string FirstStop { get; set; } = null!;
        public string LastStop { get; set; } = null!;
        public string? Alias { get; set; }
        public string Color { get; set; } = null!;
        public int CompanyId { get; set; }
        public int VehicleTypeId { get; set; }
        public string OldCode { get; set; } = null!;
        public byte[]? Logo { get; set; }
        public Company Company { get; set; } = null!;
        public VehicleType VehicleType { get; set; } = null!;
    }
}