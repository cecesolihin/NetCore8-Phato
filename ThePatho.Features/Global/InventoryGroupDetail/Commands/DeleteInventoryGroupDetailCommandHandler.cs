using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupDetail.Service;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands
{
    public class DeleteInventoryGroupDetailCommandHandler : IRequestHandler<DeleteInventoryGroupDetailCommand, ApiResponse>
    {
        private readonly IInventoryGroupDetailService Service;

        public DeleteInventoryGroupDetailCommandHandler(IInventoryGroupDetailService _inventorygroupdetailService)
        {
            Service = _inventorygroupdetailService;
        }

        public async Task<ApiResponse> Handle(DeleteInventoryGroupDetailCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteInventoryGroupDetail(request);
        }
    }
}

