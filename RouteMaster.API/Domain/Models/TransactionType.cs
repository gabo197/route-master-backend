namespace RouteMaster.API.Domain.Models;

public class TransactionType
{
    public int TransactionTypeId { get; set; }
    public string Name { get; set; } = null!;
    public ICollection<Transaction> Transactions { get; set; } = null!;
}
