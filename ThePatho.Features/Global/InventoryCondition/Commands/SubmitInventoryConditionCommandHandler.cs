using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.Service;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class SubmitInventoryConditionCommandHandler : IRequestHandler<SubmitInventoryConditionCommand, ApiResponse>
    {
        private readonly IInventoryConditionService inventoryConditionService;

        public SubmitInventoryConditionCommandHandler(IInventoryConditionService _inventoryConditionService)
        {
            inventoryConditionService = _inventoryConditionService;
        }

        public async Task<ApiResponse> Handle(SubmitInventoryConditionCommand request, CancellationToken cancellationToken)
        {
            return await inventoryConditionService.SubmitInventoryCondition(request);
        }
    }
}


