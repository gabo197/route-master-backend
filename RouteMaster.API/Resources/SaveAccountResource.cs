using RouteMaster.API.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public abstract class SaveAccountResource
    {
        [Required]
        public AccountTypes AccountType { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        public string? MiddleName { get; set; }
        [Required]
        public string LastName { get; set; } = null!;
        public string? LastName2 { get; set; }
        public string? PhoneNumber { get; set; }
        [Required]
        public bool IsActive { get; set; }
    }
}
