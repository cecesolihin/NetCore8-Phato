using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.Service;
using ThePatho.Features.Organization.CostCenter.DTO;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class GetCostCenterByCriteriaCommandHandler : IRequestHandler<GetCostCenterByCriteriaCommand, ApiResponse<CostCenterItemDto>>
    {
        private readonly ICostCenterService Service;

        public GetCostCenterByCriteriaCommandHandler(ICostCenterService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<CostCenterItemDto>> Handle(GetCostCenterByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetCostCenterByCriteria(request);
        }
    }
}
