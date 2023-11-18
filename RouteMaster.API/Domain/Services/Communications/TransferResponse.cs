using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class TransferResponse : BaseResponse<Transaction>
    {
        public TransferResponse(Transaction resource) : base(resource)
        {
        }

        public TransferResponse(string message) : base(message)
        {
        }
    }
}