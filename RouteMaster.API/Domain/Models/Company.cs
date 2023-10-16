namespace RouteMaster.API.Domain.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<BusLine> BusLines { get; set; } = null!;
    }
}