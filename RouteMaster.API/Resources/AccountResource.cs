using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Resources
{
    public abstract class AccountResource
    {
        public int UserId { get; set; }
        public AccountTypes AccountType { get; set; }
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = null!;
        public string? LastName2 { get; set; }
        public string? PhoneNumber { get; set; }
        public bool IsActive { get; set; }
        public UserResource User { get; set; } = null!;
    }
}
