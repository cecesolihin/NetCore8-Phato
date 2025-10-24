using MediatR;
using System.Net;
using ThePatho.Features.Identity.Authentication.Service;
using ThePatho.Provider.ApiResponse;
using ThePatho.Provider.Jwt;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, ApiResponse<JwtResult>>
    {
        private readonly IAuthenticationService _authenticationService;
        
        public RefreshTokenCommandHandler(IAuthenticationService authenticationService)
        {
           _authenticationService = authenticationService;
        }
        
        public async Task<ApiResponse<JwtResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            return await _authenticationService.RefreshTokenAsync(request, cancellationToken);
        }
    }
}