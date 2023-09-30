namespace RouteMaster.API.Resources;

public class WalletResource
{
    public int WalletId { get; set; }
    public int UserId { get; set; }
    public decimal Balance { get; set; }
    public DateTime LastUpdate { get; set; }
}
