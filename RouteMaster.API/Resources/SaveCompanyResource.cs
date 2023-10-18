using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SaveCompanyResource
    {
        [Required]
        public string Name { get; set; } = null!;
    }
}
