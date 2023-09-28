using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API;

public class EmailRequest
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
}
