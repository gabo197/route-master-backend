namespace RouteMaster.API.Models
{
    public class District
    {
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public int DistrictId { get; set; }
        public string Name { get; set; } = null!;
        public Country Country { get; set; } = null!;
        public Department Department { get; set; } = null!;
        public Province Province { get; set; } = null!;
    }
}