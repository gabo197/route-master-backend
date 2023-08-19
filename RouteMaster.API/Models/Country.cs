namespace RouteMaster.API.Models
{
    public class Country
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public ICollection<Department> Departments { get; set; } = null!;
    }
}
