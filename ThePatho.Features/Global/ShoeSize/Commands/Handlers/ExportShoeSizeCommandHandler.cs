using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.ShoeSize.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ShoeSize.Commands.Handlers
{
    public class ExportShoeSizeCommandHandler : IRequestHandler<ExportShoeSizeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IShoeSizeService _service;
        public ExportShoeSizeCommandHandler(IShoeSizeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportShoeSizeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
