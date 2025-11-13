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
        Task<ApiResponse<JwtResult>> RefreshTokenAsync(RefreshTokenCommand request, CancellationToken token);
        Task<JwtResult> Authenticate(User user, CancellationToken token);
        Task<ApiResponse> ChangePasswordAsync(Commands.ChangePasswordCommand request, CancellationToken token);
        Task<ApiResponse> ResetPasswordAsync(Commands.ResetPasswordCommand request, CancellationToken token);
    }
}
