using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class PaymentTransactionResponse : BaseResponse<PaymentTransaction>
    {
        public PaymentTransactionResponse(PaymentTransaction resource) : base(resource)
        {
        }

        public PaymentTransactionResponse(string message) : base(message)
        {
        }
    }
}