using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class ExportOrgStructureCommandHandler : IRequestHandler<ExportOrgStructureCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IOrgStructureService orgStructureService;

        public ExportOrgStructureCommandHandler(IOrgStructureService _orgStructureService)
        {
            orgStructureService = _orgStructureService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportOrgStructureCommand request, CancellationToken cancellationToken)
        {
            return await orgStructureService.ExportOrgStructureAsync(request.Type);
        }
    }
}