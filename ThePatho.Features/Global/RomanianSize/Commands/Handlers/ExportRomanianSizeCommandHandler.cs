using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.RomanianSize.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.RomanianSize.Commands.Handlers
{
    public class ExportRomanianSizeCommandHandler : IRequestHandler<ExportRomanianSizeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IRomanianSizeService _service;
        public ExportRomanianSizeCommandHandler(IRomanianSizeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportRomanianSizeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
