using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class RechargeTransactionResponse : BaseResponse<RechargeTransaction>
    {
        public RechargeTransactionResponse(RechargeTransaction resource) : base(resource)
        {
        }

        public RechargeTransactionResponse(string message) : base(message)
        {
        }
    }
}