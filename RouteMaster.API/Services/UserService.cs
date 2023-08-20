using AutoMapper;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RouteMaster.API.Domain.Models;
using RouteMaster.API.Domain.Persistence.Repos;
using RouteMaster.API.Domain.Services;
using RouteMaster.API.Domain.Services.Communications;
using RouteMaster.API.Settings;
using RouteMaster.API.Util;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RouteMaster.API.Services
{
    public class UserService : IUserService
    {
        private AppSettings appSettings;
        private readonly IUserRepo userRepo;
        private readonly IUnitOfWork unitOfWork;

        public UserService(IOptions<AppSettings> appSettings, IUserRepo userRepo, IUnitOfWork unitOfWork)
        {
            this.appSettings = appSettings.Value;
            this.userRepo = userRepo;
            this.unitOfWork = unitOfWork;
        }

        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(14),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<AuthenticationResponse?> Authenticate(AuthenticationRequest request)
        {
            var users = await userRepo.ListAsync();
            var user = users.SingleOrDefault(x => x.Email == request.Email);

            if (user == null)
                return null;

            if (PasswordHasher.Validate(passwordHash: user.Password, password: request.Password) == false)
                return null;

            var token = GenerateJwtToken(user);
            return new AuthenticationResponse(user, token);
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
                user.Password = PasswordHasher.Hash(user.Password);
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
