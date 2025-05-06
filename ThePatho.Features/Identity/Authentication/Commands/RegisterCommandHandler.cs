using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.Authentication.Service;
using ThePatho.Provider.Jwt;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ApiResponse<JwtResult>>
    {
        private readonly IAuthenticationService authenticationService;
        public RegisterCommandHandler(IAuthenticationService _authenticationService)
        {
           authenticationService = _authenticationService;
        }
        public async Task<ApiResponse<JwtResult>> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            return await authenticationService.RegisterAsync(request);
          
        }
    }
}
