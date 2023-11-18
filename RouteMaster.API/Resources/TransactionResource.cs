namespace RouteMaster.API.Resources
{
    public class TransactionResource
    {
        public int TransactionId { get; set; }
        public int TransactionTypeId { get; set; }
        public TransactionTypeResource TransactionType { get; set; } = null!;
        public int WalletId { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Status { get; set; } = null!;
        public string Description { get; set; } = null!;
        public int? RecipientWalletId { get; set; }
    }
}