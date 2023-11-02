using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IBusLineStopRepo
    {
        Task AddAsync(BusLineStop busLineStop);
    }
}