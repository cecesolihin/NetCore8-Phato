using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.Service;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class SubmitInventoryGroupOrgCommandHandler : IRequestHandler<SubmitInventoryGroupOrgCommand, ApiResponse>
    {
        private readonly IInventoryGroupOrgService Service;

        public SubmitInventoryGroupOrgCommandHandler(IInventoryGroupOrgService _inventorygrouporgService)
        {
            Service = _inventorygrouporgService;
        }

        public async Task<ApiResponse> Handle(SubmitInventoryGroupOrgCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitInventoryGroupOrg(request);
        }
    }
}

