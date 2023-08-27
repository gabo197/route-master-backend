namespace RouteMaster.API.Domain.Models
{
    public class AccountType
    {
        public int AccountTypeId { get; set; }
        public string Name { get; set; } = null!;
        public ICollection<Account> Accounts { get; set; } = null!;
    }
}
