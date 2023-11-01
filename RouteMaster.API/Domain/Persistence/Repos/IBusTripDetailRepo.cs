using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IBusTripDetailRepo
    {
        Task AddAsync(BusTripDetail busTripDetail);
        Task<BusTripDetail?> FindById(int busTripDetailId);
        void Update(BusTripDetail busTripDetail);
    }
}
