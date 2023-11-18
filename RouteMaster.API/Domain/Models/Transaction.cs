namespace RouteMaster.API.Domain.Models;

public abstract class Transaction
{
    public int TransactionId { get; set; }
    public int TransactionTypeId { get; set; }
    public TransactionType TransactionType { get; set; } = null!;
    public int WalletId { get; set; }
    public Wallet Wallet { get; set; } = null!;
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Status { get; set; } = null!;
    public string Description { get; set; } = null!;
    public int? RecipientWalletId { get; set; }
    public Wallet? RecipientWallet { get; set; }
}
