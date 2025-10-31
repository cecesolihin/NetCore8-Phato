using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.Service;
using ThePatho.Features.Organization.CostCenter.DTO;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class GetCostCenterCommandHandler : IRequestHandler<GetCostCenterCommand, ApiResponse<CostCenterItemDto>>
    {
        private readonly ICostCenterService Service;

        public GetCostCenterCommandHandler(ICostCenterService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<CostCenterItemDto>> Handle(GetCostCenterCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetCostCenter(request);
        }
    }
}
