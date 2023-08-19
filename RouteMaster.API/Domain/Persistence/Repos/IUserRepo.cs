using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Persistence.Repos
{
    public interface IUserRepo
    {
        Task<IEnumerable<User>> ListAsync();
        Task AddAsync(User user);
        Task<User?> FindById(int id);
        void Update(User user);
        void Remove(User user);
    }
}
