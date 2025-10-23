using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.Service;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class DeleteInventoryGroupCommandHandler : IRequestHandler<DeleteInventoryGroupCommand, ApiResponse>
    {
        private readonly IInventoryGroupService Service;

        public DeleteInventoryGroupCommandHandler(IInventoryGroupService _inventorygroupService)
        {
            Service = _inventorygroupService;
        }

        public async Task<ApiResponse> Handle(DeleteInventoryGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteInventoryGroup(request);
        }
    }
}

