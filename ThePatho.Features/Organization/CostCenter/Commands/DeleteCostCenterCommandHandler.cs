using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.Service;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class DeleteCostCenterCommandHandler : IRequestHandler<DeleteCostCenterCommand, ApiResponse>
    {
        private readonly ICostCenterService Service;

        public DeleteCostCenterCommandHandler(ICostCenterService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse> Handle(DeleteCostCenterCommand request, CancellationToken cancellationToken)
        {
            return await Service.DeleteCostCenter(request);
        }
    }
}
