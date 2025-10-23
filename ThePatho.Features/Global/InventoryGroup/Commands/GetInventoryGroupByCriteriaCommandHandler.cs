using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.DTO;
using ThePatho.Features.Global.InventoryGroup.Service;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class GetInventoryGroupByCriteriaCommandHandler : IRequestHandler<GetInventoryGroupByCriteriaCommand, ApiResponse<InventoryGroupItemDto>>
    {
        private readonly IInventoryGroupService Service;

        public GetInventoryGroupByCriteriaCommandHandler(IInventoryGroupService _inventorygroupService)
        {
            Service = _inventorygroupService;
        }

        public async Task<ApiResponse<InventoryGroupItemDto>> Handle(GetInventoryGroupByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetInventoryGroupByCriteria(request);
        }
    }
}

