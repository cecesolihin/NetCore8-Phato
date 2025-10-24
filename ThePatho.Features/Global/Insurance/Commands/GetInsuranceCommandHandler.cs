using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Insurance.Service;
using ThePatho.Features.Global.Insurance.DTO;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class GetInsuranceCommandHandler : IRequestHandler<GetInsuranceCommand, ApiResponse<InsuranceItemDto>>
    {
        private readonly IInsuranceService insuranceService;

        public GetInsuranceCommandHandler(IInsuranceService _insuranceService)
        {
            insuranceService = _insuranceService;
        }

        public async Task<ApiResponse<InsuranceItemDto>> Handle(GetInsuranceCommand request, CancellationToken cancellationToken)
        {
            return await insuranceService.GetInsurance(request);
        }
    }
}




