using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public abstract class SaveTransactionResource
    {
        [Required]
        public int WalletId { get; set; }
        [Required]
        public decimal Amount { get; set; }
        [Required]
        public DateTime Date { get; set; }
        [Required]
        public string Status { get; set; } = null!;
        [Required]
        public string Description { get; set; } = null!;
    }
}