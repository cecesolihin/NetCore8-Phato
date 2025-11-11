using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Insurance.Service;

namespace ThePatho.Features.Global.Insurance.Commands
{
    public class DeleteInsuranceCommandHandler : IRequestHandler<DeleteInsuranceCommand, ApiResponse>
    {
        private readonly IInsuranceService insuranceService;

        public DeleteInsuranceCommandHandler(IInsuranceService _insuranceService)
        {
            insuranceService = _insuranceService;
        }

        public async Task<ApiResponse> Handle(DeleteInsuranceCommand request, CancellationToken cancellationToken)
        {
            return await insuranceService.DeleteInsurance(request);
        }
    }
}





