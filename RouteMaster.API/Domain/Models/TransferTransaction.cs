namespace RouteMaster.API.Domain.Models;

public class TransferTransaction : Transaction
{
    public int RecipientWalletId { get; set; }
    public Wallet RecipientWallet { get; set; } = null!;
}
