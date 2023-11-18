using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class TransferTransactionResponse : BaseResponse<TransferTransaction>
    {
        public TransferTransactionResponse(TransferTransaction resource) : base(resource)
        {
        }

        public TransferTransactionResponse(string message) : base(message)
        {
        }
    }
}