using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface ITransferTransactionRepo
    {
        Task AddAsync(TransferTransaction transaction);
    }
}