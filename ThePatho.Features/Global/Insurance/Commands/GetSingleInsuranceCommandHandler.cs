using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Insurance.Service;
using ThePatho.Features.Global.Insurance.DTO;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class GetSingleInsuranceCommandHandler : IRequestHandler<GetSingleInsuranceCommand, ApiResponse<InsuranceDto>>
    {
        private readonly IInsuranceService Service;

        public GetSingleInsuranceCommandHandler(IInsuranceService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<InsuranceDto>> Handle(GetSingleInsuranceCommand request, CancellationToken cancellationToken)
        {
            return await Service.GetSingleInsurance(request);
        }
    }
}
