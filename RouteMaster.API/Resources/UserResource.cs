using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Resources
{
    public class UserResource
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? Token { get; set; }
        public bool IsActive { get; set; }
    }
}
