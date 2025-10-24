using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.Service;
using ThePatho.Features.Global.InventoryCondition.DTO;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class GetInventoryConditionCommandHandler : IRequestHandler<GetInventoryConditionCommand, ApiResponse<InventoryConditionItemDto>>
    {
        private readonly IInventoryConditionService inventoryConditionService;

        public GetInventoryConditionCommandHandler(IInventoryConditionService _inventoryConditionService)
        {
            inventoryConditionService = _inventoryConditionService;
        }

        public async Task<ApiResponse<InventoryConditionItemDto>> Handle(GetInventoryConditionCommand request, CancellationToken cancellationToken)
        {
            return await inventoryConditionService.GetInventoryCondition(request);
        }
    }
}




