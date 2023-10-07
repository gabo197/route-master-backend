using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SaveUserResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        public string? Username { get; set; }

        [MaxLength(30)]
        public string? Password { get; set; }
        public string? Token { get; set; }
        public string? GoogleId { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
