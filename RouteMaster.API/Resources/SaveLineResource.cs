using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SaveLineResource
    {
        [Required]
        public string Code { get; set; } = null!;
        [Required]
        public string FirstStop { get; set; } = null!;
        [Required]
        public string LastStop { get; set; } = null!;
        public string? Alias { get; set; }
        [Required]
        public string Color { get; set; } = null!;
        [Required]
        public int CompanyId { get; set; }
    }
}
