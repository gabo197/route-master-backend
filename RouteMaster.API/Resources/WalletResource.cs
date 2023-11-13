namespace RouteMaster.API.Resources;

public class WalletResource
{
    public int WalletId { get; set; }
    public int UserId { get; set; }
    public string Balance { get; set; } = null!;
    public DateTime LastUpdate { get; set; }
}
