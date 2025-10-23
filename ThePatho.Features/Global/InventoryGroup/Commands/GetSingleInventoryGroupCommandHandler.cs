using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryGroup.DTO;
using ThePatho.Features.Global.InventoryGroup.Service;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class GetSingleInventoryGroupCommandHandler : IRequestHandler<GetSingleInventoryGroupCommand, ApiResponse<InventoryGroupDto>>
    {
        private readonly IInventoryGroupService Service;

        public GetSingleInventoryGroupCommandHandler(IInventoryGroupService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<InventoryGroupDto>> Handle(GetSingleInventoryGroupCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleInventoryGroup(request);
        }
    }
}
