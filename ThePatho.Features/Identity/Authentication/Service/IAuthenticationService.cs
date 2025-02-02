using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.ConfigurationExtensions.Jwt;
using ThePatho.Features.Identity.Authentication.Commands;

namespace ThePatho.Features.Identity.Authentication.Service
{
    public interface IAuthenticationService
    {
        Task<NewApiResponse<JwtResult>> RegisterAsync(RegisterCommand request);
        Task<NewApiResponse<JwtResult>> LoginAsync(LoginCommand request);
    }
}
