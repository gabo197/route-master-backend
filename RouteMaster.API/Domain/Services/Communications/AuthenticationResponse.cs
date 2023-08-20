using RouteMaster.API.Domain.Models;

namespace RouteMaster.API.Domain.Services.Communications
{
    public class AuthenticationResponse
    {
        public int UserId { get; set; }
        public string Email { get; set; } = null!;
        public string Token { get; set; } = null!;
        public AuthenticationResponse(User user, string token)
        {
            UserId = user.UserId;
            Email = user.Email;
            Token = token;
        }

        public AuthenticationResponse()
        {
        }
    }
}
