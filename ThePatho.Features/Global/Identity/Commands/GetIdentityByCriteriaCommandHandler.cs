using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Identity.DTO;
using ThePatho.Features.Global.Identity.Service;

namespace ThePatho.Features.Global.Identity.Commands
{
    public class GetIdentityByCriteriaCommandHandler : IRequestHandler<GetIdentityByCriteriaCommand, ApiResponse<IdentityItemDto>>
    {
        private readonly IIdentityService Service;

        public GetIdentityByCriteriaCommandHandler(IIdentityService _identityService)
        {
            Service = _identityService;
        }

        public async Task<ApiResponse<IdentityItemDto>> Handle(GetIdentityByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetIdentityByCriteria(request);
        }
    }
}

