using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.Service;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class DeleteIdentityCommandHandler : IRequestHandler<DeleteIdentityCommand, ApiResponse>
    {
        private readonly IIdentityService Service;

        public DeleteIdentityCommandHandler(IIdentityService _identityService)
        {
            Service = _identityService;
        }

        public async Task<ApiResponse> Handle(DeleteIdentityCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteIdentity(request);
        }
    }
}

