namespace RouteMaster.API.Domain.Models;

public class Wallet
{
    public int WalletId { get; set; }
    public int UserId { get; set; }
    public Passenger Passenger { get; set; } = null!;
    public decimal Balance { get; set; }
    public DateTime LastUpdate { get; set; }
    public ICollection<RechargeTransaction> RechargeTransactions { get; set; } = null!;
    public ICollection<PaymentTransaction> PaymentTransactions { get; set; } = null!;
    public ICollection<TransferTransaction> SentTransferTransactions { get; set; } = null!;
    public ICollection<TransferTransaction> RecievedTransferTransactions { get; set; } = null!;
}
