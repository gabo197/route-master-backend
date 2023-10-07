using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class AuthenticationRequest
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;
        public string? Password { get; set; }
    }
}
