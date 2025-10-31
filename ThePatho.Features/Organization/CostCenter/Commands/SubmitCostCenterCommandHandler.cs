using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.Service;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class SubmitCostCenterCommandHandler : IRequestHandler<SubmitCostCenterCommand, ApiResponse>
    {
        private readonly ICostCenterService Service;

        public SubmitCostCenterCommandHandler(ICostCenterService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(SubmitCostCenterCommand request, CancellationToken cancellationToken)
        {
            return await Service.SubmitCostCenter(request);
        }
    }
}
