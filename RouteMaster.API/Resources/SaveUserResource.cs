using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SaveUserResource
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        public string Username { get; set; } = null!;

        [Required]
        [MaxLength(30)]
        public string Password { get; set; } = null!;
        public string? Token { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
