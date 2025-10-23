using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.DTO;
using ThePatho.Features.Global.InventoryGroupOrg.Service;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class GetInventoryGroupOrgCommandHandler : IRequestHandler<GetInventoryGroupOrgCommand, ApiResponse<InventoryGroupOrgItemDto>>
    {
        private readonly IInventoryGroupOrgService Service;

        public GetInventoryGroupOrgCommandHandler(IInventoryGroupOrgService _inventorygrouporgService)
        {
            Service = _inventorygrouporgService;
        }

        public async Task<ApiResponse<InventoryGroupOrgItemDto>> Handle(GetInventoryGroupOrgCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetInventoryGroupOrg(request);
        }
    }
}

