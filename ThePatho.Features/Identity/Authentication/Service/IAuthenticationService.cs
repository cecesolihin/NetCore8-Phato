using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.Authentication.Commands;
using ThePatho.Provider.Jwt;
using ThePatho.Domain.Models.Identity;

namespace ThePatho.Features.Identity.Authentication.Service
{
    public interface IAuthenticationService
    {
        Task<ApiResponse<JwtResult>> RegisterAsync(RegisterCommand request);
        Task<ApiResponse<JwtResult>> LoginAsync(LoginCommand request, CancellationToken token);
        Task<JwtResult> Authenticate(User user, CancellationToken token);
    }
}
