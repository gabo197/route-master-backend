using System.Diagnostics.Metrics;

namespace RouteMaster.API.Models
{
    public class Address
    {
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string StreetLine1 { get; set; } = null!;
        public string? StreetLine2 { get; set; }
        public string? ZipCode { get; set; }
        public Country Country { get; set; } = null!;
        public Department Department { get; set; } = null!;
        public Province Province { get; set; } = null!;
        public District District { get; set; } = null!;
    }
}
