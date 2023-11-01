namespace RouteMaster.API.Domain.Models
{
    public abstract class Driver
    {
        public int DriverId { get; set; }
        public int VehicleTypeId { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DocumentType DocumentType { get; set; } = null!;
        public VehicleType VehicleType { get; set; } = null!;
        public int? VehicleId { get; set; }
    }
}
