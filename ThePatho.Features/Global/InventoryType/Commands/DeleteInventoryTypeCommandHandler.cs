using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.Service;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class DeleteInventoryTypeCommandHandler : IRequestHandler<DeleteInventoryTypeCommand, ApiResponse>
    {
        private readonly IInventoryTypeService inventoryTypeService;

        public DeleteInventoryTypeCommandHandler(IInventoryTypeService _inventoryTypeService)
        {
            inventoryTypeService = _inventoryTypeService;
        }

        public async Task<ApiResponse> Handle(DeleteInventoryTypeCommand request, CancellationToken cancellationToken)
        {
            return await inventoryTypeService.DeleteInventoryType(request);
        }
    }
}
