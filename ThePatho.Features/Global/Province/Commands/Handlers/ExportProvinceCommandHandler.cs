using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Province.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Province.Commands.Handlers
{
    public class ExportProvinceCommandHandler : IRequestHandler<ExportProvinceCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IProvinceService _service;
        public ExportProvinceCommandHandler(IProvinceService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportProvinceCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
