using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Domain.Models
{
    public abstract class Account
    {
        [Key]
        public int UserId { get; set; }
        public int AccountTypeId { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? LastName2 { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public AccountType AccountType { get; set; } = null!;
        public User User { get; set; } = null!;
    }
}
