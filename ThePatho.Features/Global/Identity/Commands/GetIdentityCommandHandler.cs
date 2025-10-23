using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.DTO;
using ThePatho.Features.Global.Identity.Service;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class GetIdentityCommandHandler : IRequestHandler<GetIdentityCommand, ApiResponse<IdentityItemDto>>
    {
        private readonly IIdentityService Service;

        public GetIdentityCommandHandler(IIdentityService _identityService)
        {
            Service = _identityService;
        }

        public async Task<ApiResponse<IdentityItemDto>> Handle(GetIdentityCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetIdentity(request);
        }
    }
}

