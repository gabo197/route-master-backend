using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; } = null!;

        [Required]
        public string Password { get; set; } = null!;
    }
}
