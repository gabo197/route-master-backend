namespace RouteMaster.API.Domain.Models
{
    public class DocumentType
    {
        public int DocumentTypeId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<BusDriver> BusDrivers { get; set; } = null!;
    }
}