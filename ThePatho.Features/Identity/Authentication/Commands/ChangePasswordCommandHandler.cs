using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Identity.Authentication.Service;

namespace ThePatho.Features.Identity.Authentication.Commands
{
    public class ChangePasswordCommandHandler : IRequestHandler<ChangePasswordCommand, ApiResponse>
    {
        private readonly IAuthenticationService authenticationService;
        public ChangePasswordCommandHandler(IAuthenticationService _authenticationService)
        {
           authenticationService = _authenticationService;
        }
        public async Task<ApiResponse> Handle(ChangePasswordCommand request, CancellationToken cancellationToken)
        {
            return await authenticationService.ChangePasswordAsync(request, cancellationToken);
        }
    }
}