using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.Authentication.Service;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class ResetPasswordCommandHandler : IRequestHandler<ResetPasswordCommand, ApiResponse>
    {
        private readonly IAuthenticationService authenticationService;
        public ResetPasswordCommandHandler(IAuthenticationService _authenticationService)
        {
           authenticationService = _authenticationService;
        }
        public async Task<ApiResponse> Handle(ResetPasswordCommand request, CancellationToken cancellationToken)
        {
            return await authenticationService.ResetPasswordAsync(request, cancellationToken);
        }
    }
}