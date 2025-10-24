using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Insurance.Service;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class SubmitInsuranceCommandHandler : IRequestHandler<SubmitInsuranceCommand, ApiResponse>
    {
        private readonly IInsuranceService insuranceService;

        public SubmitInsuranceCommandHandler(IInsuranceService _insuranceService)
        {
            insuranceService = _insuranceService;
        }

        public async Task<ApiResponse> Handle(SubmitInsuranceCommand request, CancellationToken cancellationToken)
        {
            return await insuranceService.SubmitInsurance(request);
        }
    }
}




