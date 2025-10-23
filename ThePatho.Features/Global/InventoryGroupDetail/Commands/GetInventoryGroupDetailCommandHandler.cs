using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupDetail.DTO;
using ThePatho.Features.Global.InventoryGroupDetail.Service;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class GetInventoryGroupDetailCommandHandler : IRequestHandler<GetInventoryGroupDetailCommand, ApiResponse<InventoryGroupDetailItemDto>>
    {
        private readonly IInventoryGroupDetailService Service;

        public GetInventoryGroupDetailCommandHandler(IInventoryGroupDetailService _inventorygroupdetailService)
        {
            Service = _inventorygroupdetailService;
        }

        public async Task<ApiResponse<InventoryGroupDetailItemDto>> Handle(GetInventoryGroupDetailCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetInventoryGroupDetail(request);
        }
    }
}

