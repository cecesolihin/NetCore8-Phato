using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.Grade.Service;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Grade.Commands
{
    public class DownloadGradeTemplateCommandHandler : IRequestHandler<DownloadGradeTemplateCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IGradeService Service;

        public DownloadGradeTemplateCommandHandler(IGradeService _Service)
        {
            Service = _Service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(DownloadGradeTemplateCommand request, CancellationToken cancellationToken)
        {
            return await Service.DownloadGradeTemplate();
        }
    }
}