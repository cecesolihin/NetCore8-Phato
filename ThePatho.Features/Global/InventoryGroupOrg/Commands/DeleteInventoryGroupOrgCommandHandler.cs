using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.Service;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class DeleteInventoryGroupOrgCommandHandler : IRequestHandler<DeleteInventoryGroupOrgCommand, ApiResponse>
    {
        private readonly IInventoryGroupOrgService Service;

        public DeleteInventoryGroupOrgCommandHandler(IInventoryGroupOrgService _inventorygrouporgService)
        {
            Service = _inventorygrouporgService;
        }

        public async Task<ApiResponse> Handle(DeleteInventoryGroupOrgCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteInventoryGroupOrg(request);
        }
    }
}

