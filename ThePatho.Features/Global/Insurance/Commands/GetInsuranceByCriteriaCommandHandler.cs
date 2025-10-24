using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Insurance.Service;
using ThePatho.Features.Global.Insurance.DTO;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class GetInsuranceByCriteriaCommandHandler : IRequestHandler<GetInsuranceByCriteriaCommand, ApiResponse<InsuranceItemDto>>
    {
        private readonly IInsuranceService insuranceService;

        public GetInsuranceByCriteriaCommandHandler(IInsuranceService _insuranceService)
        {
            insuranceService = _insuranceService;
        }

        public async Task<ApiResponse<InsuranceItemDto>> Handle(GetInsuranceByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await insuranceService.GetInsuranceByCriteria(request);
        }
    }
}




