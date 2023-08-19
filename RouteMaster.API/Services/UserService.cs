using AutoMapper;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;

namespace RouteMaster.API.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepo userRepo;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IUserRepo userRepo, IUnitOfWork unitOfWork)
        {
            this.userRepo = userRepo;
            this.unitOfWork = unitOfWork;
        }

        public async Task<UserResponse> DeleteAsync(int id)
        {
            var existingUser = await userRepo.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            try
            {
                userRepo.Remove(existingUser);
                await unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while deleting the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> GetByIdAsync(int id)
        {
            var existingUser = await userRepo.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");
            return new UserResponse(existingUser);
        }

        public async Task<IEnumerable<User>> ListAsync()
        {
            return await userRepo.ListAsync();
        }

        public async Task<UserResponse> SaveAsync(User user)
        {
            try
            {
                await userRepo.AddAsync(user);
                await unitOfWork.CompleteAsync();

                return new UserResponse(user);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while saving the user: {ex.Message}");
            }
        }

        public async Task<UserResponse> UpdateAsync(int id, User user)
        {
            var existingUser = await userRepo.FindById(id);

            if (existingUser == null)
                return new UserResponse("User not found");

            existingUser.Email = user.Email;
            existingUser.Password = user.Password;

            try
            {
                userRepo.Update(existingUser);
                await unitOfWork.CompleteAsync();

                return new UserResponse(existingUser);
            }
            catch (Exception ex)
            {
                return new UserResponse($"An error ocurred while updating the user: {ex.Message}");
            }
        }
    }
}
