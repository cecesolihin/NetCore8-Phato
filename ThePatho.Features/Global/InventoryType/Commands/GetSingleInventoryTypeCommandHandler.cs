using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryType.Service;
using ThePatho.Features.Global.InventoryType.DTO;

namespace ThePatho.Features.Global.InventoryType.Commands
{
    public class GetSingleInventoryTypeCommandHandler : IRequestHandler<GetSingleInventoryTypeCommand, ApiResponse<InventoryTypeDto>>
    {
        private readonly IInventoryTypeService Service;

        public GetSingleInventoryTypeCommandHandler(IInventoryTypeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<InventoryTypeDto>> Handle(GetSingleInventoryTypeCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleInventoryType(request);
        }
    }
}
