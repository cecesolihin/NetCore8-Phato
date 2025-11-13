using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.CostCenter.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class ExportCostCenterCommandHandler : IRequestHandler<ExportCostCenterCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ICostCenterService service;

        public ExportCostCenterCommandHandler(ICostCenterService service)
        {
            this.service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportCostCenterCommand request, CancellationToken cancellationToken)
        {
            return await service.ExportCostCenterAsync(request.Type);
        }
    }
}