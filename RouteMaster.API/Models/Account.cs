using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Models
{
    public enum AccountTypes
    {
        Administrator,
        Passenger
    };

    public abstract class Account
    {
        [Key]
        public int UserId { get; set; }
        public AccountTypes AccountType { get; set; }
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? LastName2 { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public User User { get; set; } = null!;
    }
}
