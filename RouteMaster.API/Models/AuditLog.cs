namespace RouteMaster.API.Models
{
    public class AuditLog
    {
        public int UserId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }
        public User User { get; set; } = null!;
    }
}
