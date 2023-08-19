using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Domain.Models
{
    public class AuditLog
    {
        [Key]
        public int UserId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }
        public Passenger Passenger { get; set; } = null!;
    }
}
