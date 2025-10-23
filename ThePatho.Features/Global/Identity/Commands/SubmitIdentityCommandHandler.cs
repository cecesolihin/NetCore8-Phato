using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.Service;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class SubmitIdentityCommandHandler : IRequestHandler<SubmitIdentityCommand, ApiResponse>
    {
        private readonly IIdentityService Service;

        public SubmitIdentityCommandHandler(IIdentityService _identityService)
        {
            Service = _identityService;
        }

        public async Task<ApiResponse> Handle(SubmitIdentityCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitIdentity(request);
        }
    }
}

