using MediatR;
using ThePatho.Features.ConfigurationExtensions.Jwt;
using ThePatho.Features.Identity.Authentication.Service;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, JwtResult>
    {
        private readonly IAuthenticationService authenticationService;
        public LoginCommandHandler(IAuthenticationService _authenticationService)
        {
           authenticationService = _authenticationService;
        }
        public async Task<JwtResult> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var token = await authenticationService.LoginAsync(request);
            return new JwtResult()
            {
                JwtToken = token,
                RefreshToken = token,
            };
        }
    }
}
