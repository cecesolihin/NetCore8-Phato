using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.Service;
using ThePatho.Features.Global.InventoryType.DTO;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class GetInventoryTypeByCriteriaCommandHandler : IRequestHandler<GetInventoryTypeByCriteriaCommand, ApiResponse<InventoryTypeItemDto>>
    {
        private readonly IInventoryTypeService inventoryTypeService;

        public GetInventoryTypeByCriteriaCommandHandler(IInventoryTypeService _inventoryTypeService)
        {
            inventoryTypeService = _inventoryTypeService;
        }

        public async Task<ApiResponse<InventoryTypeItemDto>> Handle(GetInventoryTypeByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await inventoryTypeService.GetInventoryTypeByCriteria(request);
        }
    }
}
