using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupDetail.DTO;
using ThePatho.Features.Global.InventoryGroupDetail.Service;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class GetSingleInventoryGroupDetailCommandHandler : IRequestHandler<GetSingleInventoryGroupDetailCommand, ApiResponse<InventoryGroupDetailDto>>
    {
        private readonly IInventoryGroupDetailService Service;

        public GetSingleInventoryGroupDetailCommandHandler(IInventoryGroupDetailService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<InventoryGroupDetailDto>> Handle(GetSingleInventoryGroupDetailCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleInventoryGroupDetail(request);
        }
    }
}
