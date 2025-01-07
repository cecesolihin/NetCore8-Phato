using MediatR;
using ThePatho.Features.ConfigurationExtensions.Jwt;
using ThePatho.Features.Identity.Authentication.Service;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, JwtResult>
    {
        private readonly IAuthenticationService authenticationService;
        public RegisterCommandHandler(IAuthenticationService _authenticationService)
        {
           authenticationService = _authenticationService;
        }
        public async Task<JwtResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var token = await authenticationService.RegisterAsync(request);
            return new JwtResult() { 
                JwtToken = token,
                RefreshToken = token,
            };
        }
    }
}
