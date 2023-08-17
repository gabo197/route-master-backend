namespace RouteMaster.API.Models
{
    public class User
    {
        public int UserId { get; set; }
        public int UserType { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
