using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Domain.Models
{
    public class Address
    {
        [Key]
        public int UserId { get; set; }
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string StreetLine1 { get; set; } = null!;
        public string? StreetLine2 { get; set; }
        public string? ZipCode { get; set; }
        public bool IsActive { get; set; }
        public Passenger Passenger { get; set; } = null!;
        public District District { get; set; } = null!;
    }
}
