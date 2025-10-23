using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.Service;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class SubmitInventoryGroupCommandHandler : IRequestHandler<SubmitInventoryGroupCommand, ApiResponse>
    {
        private readonly IInventoryGroupService Service;

        public SubmitInventoryGroupCommandHandler(IInventoryGroupService _inventorygroupService)
        {
            Service = _inventorygroupService;
        }

        public async Task<ApiResponse> Handle(SubmitInventoryGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitInventoryGroup(request);
        }
    }
}

