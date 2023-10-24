namespace RouteMaster.API.Resources
{
    public abstract class LineResource
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
        public CompanyResource Company { get; set; } = null!;
        public VehicleTypeResource VehicleType { get; set; } = null!;
    }
}
