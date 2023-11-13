using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API;

public class SaveWalletResource
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public string Balance { get; set; } = null!;
    [Required]
    public DateTime LastUpdate { get; set; }
}
