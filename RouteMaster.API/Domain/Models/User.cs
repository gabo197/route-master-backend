namespace RouteMaster.API.Domain.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string? Username { get; set; }
        public string? Password { get; set; }
        public string? Token { get; set; }
        public bool IsActive { get; set; }
        public string? GoogleId { get; set; }
        public Account Account { get; set; } = null!;
    }
}