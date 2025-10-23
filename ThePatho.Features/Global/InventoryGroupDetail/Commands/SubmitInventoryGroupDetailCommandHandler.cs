using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupDetail.Service;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class SubmitInventoryGroupDetailCommandHandler : IRequestHandler<SubmitInventoryGroupDetailCommand, ApiResponse>
    {
        private readonly IInventoryGroupDetailService Service;

        public SubmitInventoryGroupDetailCommandHandler(IInventoryGroupDetailService _inventorygroupdetailService)
        {
            Service = _inventorygroupdetailService;
        }

        public async Task<ApiResponse> Handle(SubmitInventoryGroupDetailCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitInventoryGroupDetail(request);
        }
    }
}

