using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface ICompanyRepo
    {
        Task<IEnumerable<Company>> ListAsync();
        Task AddAsync(Company company);
        Task<Company?> FindByIdAsync(int id);
        void Update(Company company);
        void Remove(Company company);
    }
}
