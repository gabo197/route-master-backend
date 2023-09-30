using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API;

public class SaveWalletResource
{
    [Required]
    public int UserId { get; set; }
    [Required]
    public decimal Balance { get; set; }
    [Required]
    public DateTime LastUpdate { get; set; }
}
