namespace RouteMaster.API.Domain.Models
{
    public class Province
    {
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public Department Department { get; set; } = null!;
        public ICollection<District> Districts { get; set; } = null!;
    }
}