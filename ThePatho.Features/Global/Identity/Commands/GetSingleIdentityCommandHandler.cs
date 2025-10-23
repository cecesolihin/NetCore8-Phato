using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.DTO;
using ThePatho.Features.Global.Identity.Service;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class GetSingleIdentityCommandHandler : IRequestHandler<GetSingleIdentityCommand, ApiResponse<IdentityDto>>
    {
        private readonly IIdentityService Service;

        public GetSingleIdentityCommandHandler(IIdentityService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<IdentityDto>> Handle(GetSingleIdentityCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleIdentity(request);
        }
    }
}
