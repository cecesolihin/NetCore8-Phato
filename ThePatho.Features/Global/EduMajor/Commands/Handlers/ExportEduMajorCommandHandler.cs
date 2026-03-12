using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.EduMajor.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.EduMajor.Commands.Handlers
{
    public class ExportEduMajorCommandHandler : IRequestHandler<ExportEduMajorCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEduMajorService _service;
        public ExportEduMajorCommandHandler(IEduMajorService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEduMajorCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
