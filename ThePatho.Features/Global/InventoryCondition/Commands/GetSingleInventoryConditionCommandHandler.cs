using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.InventoryCondition.Service;
using ThePatho.Features.Global.InventoryCondition.DTO;

namespace ThePatho.Features.Global.InventoryCondition.Commands
{
    public class GetSingleInventoryConditionCommandHandler : IRequestHandler<GetSingleInventoryConditionCommand, ApiResponse<InventoryConditionDto>>
    {
        private readonly IInventoryConditionService Service;

        public GetSingleInventoryConditionCommandHandler(IInventoryConditionService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<InventoryConditionDto>> Handle(GetSingleInventoryConditionCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleInventoryCondition(request);
        }
    }
}
