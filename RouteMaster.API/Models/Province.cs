namespace RouteMaster.API.Models
{
    public class Province
    {
        public int CountryId { get; set; }
        public int DepartmentId { get; set; }
        public int ProvinceId { get; set; }
        public string Name { get; set; } = null!;
        public Country Country { get; set; } = null!;
        public Department Department { get; set; } = null!;
    }
}