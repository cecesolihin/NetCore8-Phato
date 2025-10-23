using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.DTO;
using ThePatho.Features.Global.InventoryGroup.Service;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class GetInventoryGroupCommandHandler : IRequestHandler<GetInventoryGroupCommand, ApiResponse<InventoryGroupItemDto>>
    {
        private readonly IInventoryGroupService Service;

        public GetInventoryGroupCommandHandler(IInventoryGroupService _inventorygroupService)
        {
            Service = _inventorygroupService;
        }

        public async Task<ApiResponse<InventoryGroupItemDto>> Handle(GetInventoryGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetInventoryGroup(request);
        }
    }
}

