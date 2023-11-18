using System.ComponentModel.DataAnnotations;

namespace RouteMaster.API.Resources
{
    public class SaveTransferTransactionResource : SaveTransactionResource
    {
        [Required]
        public int RecipientWalletId { get; set; }
    }
}