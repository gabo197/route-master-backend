using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Resources
{
    public class ProvinceResource
    {
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public DepartmentResource Department { get; set; } = null!;
    }
}