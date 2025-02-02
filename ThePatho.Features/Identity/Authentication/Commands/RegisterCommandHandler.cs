using MediatR;
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.ConfigurationExtensions.Jwt;
using ThePatho.Features.Identity.Authentication.Service;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, NewApiResponse<JwtResult>>
    {
        private readonly IAuthenticationService authenticationService;
        public RegisterCommandHandler(IAuthenticationService _authenticationService)
        {
           authenticationService = _authenticationService;
        }
        public async Task<NewApiResponse<JwtResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await authenticationService.RegisterAsync(request);
          
        }
    }
}
