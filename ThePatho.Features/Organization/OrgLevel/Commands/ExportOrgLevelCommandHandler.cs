using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Commands
{
    public class ExportOrgLevelCommandHandler : IRequestHandler<ExportOrgLevelCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IOrgLevelService orgLevelService;

        public ExportOrgLevelCommandHandler(IOrgLevelService _orgLevelService)
        {
            orgLevelService = _orgLevelService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportOrgLevelCommand request, CancellationToken cancellationToken)
        {
            return await orgLevelService.ExportOrgLevelAsync(request.Type);
        }
    }
}