using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.Service;
using ThePatho.Features.Global.InventoryType.DTO;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class GetInventoryTypeCommandHandler : IRequestHandler<GetInventoryTypeCommand, ApiResponse<InventoryTypeItemDto>>
    {
        private readonly IInventoryTypeService inventoryTypeService;

        public GetInventoryTypeCommandHandler(IInventoryTypeService _inventoryTypeService)
        {
            inventoryTypeService = _inventoryTypeService;
        }

        public async Task<ApiResponse<InventoryTypeItemDto>> Handle(GetInventoryTypeCommand request, CancellationToken cancellationToken)
        {
            return await inventoryTypeService.GetInventoryType(request);
        }
    }
}
