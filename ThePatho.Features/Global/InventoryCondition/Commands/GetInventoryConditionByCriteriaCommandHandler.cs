using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.Service;
using ThePatho.Features.Global.InventoryCondition.DTO;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class GetInventoryConditionByCriteriaCommandHandler : IRequestHandler<GetInventoryConditionByCriteriaCommand, ApiResponse<InventoryConditionItemDto>>
    {
        private readonly IInventoryConditionService inventoryConditionService;

        public GetInventoryConditionByCriteriaCommandHandler(IInventoryConditionService _inventoryConditionService)
        {
            inventoryConditionService = _inventoryConditionService;
        }

        public async Task<ApiResponse<InventoryConditionItemDto>> Handle(GetInventoryConditionByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await inventoryConditionService.GetInventoryConditionByCriteria(request);
        }
    }
}




