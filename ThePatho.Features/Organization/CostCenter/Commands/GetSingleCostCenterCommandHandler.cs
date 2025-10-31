using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.Service;
using ThePatho.Features.Organization.CostCenter.DTO;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class GetSingleCostCenterCommandHandler : IRequestHandler<GetSingleCostCenterCommand, ApiResponse<CostCenterDto>>
    {
        private readonly ICostCenterService Service;

        public GetSingleCostCenterCommandHandler(ICostCenterService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<CostCenterDto>> Handle(GetSingleCostCenterCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleCostCenter(request);
        }
    }
}
