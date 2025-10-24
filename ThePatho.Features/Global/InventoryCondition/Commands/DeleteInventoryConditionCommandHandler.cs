using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.Service;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class DeleteInventoryConditionCommandHandler : IRequestHandler<DeleteInventoryConditionCommand, ApiResponse>
    {
        private readonly IInventoryConditionService inventoryConditionService;

        public DeleteInventoryConditionCommandHandler(IInventoryConditionService _inventoryConditionService)
        {
            inventoryConditionService = _inventoryConditionService;
        }

        public async Task<ApiResponse> Handle(DeleteInventoryConditionCommand request, CancellationToken cancellationToken)
        {
            return await inventoryConditionService.DeleteInventoryCondition(request);
        }
    }
}




