using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.Service;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class SubmitInventoryTypeCommandHandler : IRequestHandler<SubmitInventoryTypeCommand, ApiResponse>
    {
        private readonly IInventoryTypeService inventoryTypeService;

        public SubmitInventoryTypeCommandHandler(IInventoryTypeService _inventoryTypeService)
        {
            inventoryTypeService = _inventoryTypeService;
        }

        public async Task<ApiResponse> Handle(SubmitInventoryTypeCommand request, CancellationToken cancellationToken)
        {
            return await inventoryTypeService.SubmitInventoryType(request);
        }
    }
}
