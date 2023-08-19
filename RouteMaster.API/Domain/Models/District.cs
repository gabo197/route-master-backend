namespace RouteMaster.API.Domain.Models
{
    public class District
    {
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public Province Province { get; set; } = null!;
        public ICollection<Address> Addresses { get; set; } = null!;
    }
}