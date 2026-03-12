using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.NumericalSize.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.NumericalSize.Commands.Handlers
{
    public class ExportNumericalSizeCommandHandler : IRequestHandler<ExportNumericalSizeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly INumericalSizeService _service;
        public ExportNumericalSizeCommandHandler(INumericalSizeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportNumericalSizeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
