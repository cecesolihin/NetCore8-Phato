using Azure;
using MediatR;
using System.Net;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.Authentication.Service;
using ThePatho.Provider.Jwt;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, ApiResponse<JwtResult>>
    {
        private readonly IAuthenticationService authenticationService;
        public LoginCommandHandler(IAuthenticationService _authenticationService)
        {
           authenticationService = _authenticationService;
        }
        public async Task<ApiResponse<JwtResult>> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            return await authenticationService.LoginAsync(request, cancellationToken);
        }
    }
}
