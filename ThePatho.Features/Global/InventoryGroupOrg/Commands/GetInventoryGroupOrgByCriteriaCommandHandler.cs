using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.DTO;
using ThePatho.Features.Global.InventoryGroupOrg.Service;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class GetInventoryGroupOrgByCriteriaCommandHandler : IRequestHandler<GetInventoryGroupOrgByCriteriaCommand, ApiResponse<InventoryGroupOrgItemDto>>
    {
        private readonly IInventoryGroupOrgService Service;

        public GetInventoryGroupOrgByCriteriaCommandHandler(IInventoryGroupOrgService _inventorygrouporgService)
        {
            Service = _inventorygrouporgService;
        }

        public async Task<ApiResponse<InventoryGroupOrgItemDto>> Handle(GetInventoryGroupOrgByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetInventoryGroupOrgByCriteria(request);
        }
    }
}

