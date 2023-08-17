namespace RouteMaster.API.Models
{
    public class Administrator
    {
        public int UserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? LastName2 { get; set; }
        public string? PhoneNumber { get; set; }
        public User User { get; set; } = null!;
    }
}
