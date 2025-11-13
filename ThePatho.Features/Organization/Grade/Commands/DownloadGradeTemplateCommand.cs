using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class DownloadGradeTemplateCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        // Reserved for future parameters (e.g., locale or status list)
    }
}