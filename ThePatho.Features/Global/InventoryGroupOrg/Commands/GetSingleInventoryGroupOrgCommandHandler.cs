using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroupOrg.DTO;
using ThePatho.Features.Global.InventoryGroupOrg.Service;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands
{
    public class GetSingleInventoryGroupOrgCommandHandler : IRequestHandler<GetSingleInventoryGroupOrgCommand, ApiResponse<InventoryGroupOrgDto>>
    {
        private readonly IInventoryGroupOrgService Service;

        public GetSingleInventoryGroupOrgCommandHandler(IInventoryGroupOrgService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<InventoryGroupOrgDto>> Handle(GetSingleInventoryGroupOrgCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleInventoryGroupOrg(request);
        }
    }
}
