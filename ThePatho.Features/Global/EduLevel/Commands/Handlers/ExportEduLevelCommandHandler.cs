using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.EduLevel.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.EduLevel.Commands.Handlers
{
    public class ExportEduLevelCommandHandler : IRequestHandler<ExportEduLevelCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IEduLevelService _service;
        public ExportEduLevelCommandHandler(IEduLevelService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportEduLevelCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
