using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Course.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Course.Commands.Handlers
{
    public class ExportCourseCommandHandler : IRequestHandler<ExportCourseCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ICourseService _service;
        public ExportCourseCommandHandler(ICourseService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportCourseCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
