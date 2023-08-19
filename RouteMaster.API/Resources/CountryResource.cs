namespace RouteMaster.API.Resources
{
    public class CountryResource
    {
        public int CountryId { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
    }
}