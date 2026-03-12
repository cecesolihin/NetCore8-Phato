using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.ResignReason.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ResignReason.Commands.Handlers
{
    public class ExportResignReasonCommandHandler : IRequestHandler<ExportResignReasonCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IResignReasonService _service;
        public ExportResignReasonCommandHandler(IResignReasonService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportResignReasonCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
