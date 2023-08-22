namespace RouteMaster.API.Resources
{
    public class AuditLogResource
    {
        public int UserId { get; set; }
        public DateTime? LastLogin { get; set; }
        public DateTime? LastLogout { get; set; }
    }
}