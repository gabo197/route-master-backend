using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Resources
{
    public class AddressResource
    {
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string StreetLine1 { get; set; } = null!;
        public string? StreetLine2 { get; set; }
        public string? ZipCode { get; set; }
        public bool IsActive { get; set; }
        public DistrictResource District { get; set; } = null!;
    }
}