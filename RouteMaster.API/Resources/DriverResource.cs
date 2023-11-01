namespace RouteMaster.API.Resources
{
    public abstract class DriverResource
    {
        public int DriverId { get; set; }
        public int VehicleTypeId { get; set; }
        public int DocumentTypeId { get; set; }
        public string DocumentNumber { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public DocumentTypeResource DocumentType { get; set; } = null!;
        public VehicleTypeResource VehicleType { get; set; } = null!;
        public int? VehicleId { get; set; }
    }
}
