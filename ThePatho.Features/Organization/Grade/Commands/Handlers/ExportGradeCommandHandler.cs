using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Organization.Grade.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.Grade.Commands.Handlers
{
    public class ExportGradeCommandHandler : IRequestHandler<ExportGradeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IGradeService _service;
        public ExportGradeCommandHandler(IGradeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportGradeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportGradeAsync(request);
        }
    }
}