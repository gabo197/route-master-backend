using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Domain.Services
{
    public interface IUserService
    {
        //Task<AuthenticationResponse> Authenticate(AuthenticationRequest request);
        Task<IEnumerable<User>> ListAsync();
        Task<UserResponse> GetByIdAsync(int id);
        Task<UserResponse> SaveAsync(User user);
        Task<UserResponse> UpdateAsync(int id, User user);
        Task<UserResponse> DeleteAsync(int id);
    }
}
