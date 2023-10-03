using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class WalletResponse : BaseResponse<Wallet>
    {
        public WalletResponse(Wallet resource) : base(resource)
        {
        }

        public WalletResponse(string message) : base(message)
        {
        }
    }
}