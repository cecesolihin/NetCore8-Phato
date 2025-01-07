using ThePatho.Features.Identity.Authentication.Commands;

namespace ThePatho.Features.Identity.Authentication.Service
{
    public interface IAuthenticationService
    {
        Task<string> RegisterAsync(RegisterCommand request);
        Task<string> LoginAsync(LoginCommand request);
    }
}
