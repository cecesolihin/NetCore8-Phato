using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.ClothSize.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.ClothSize.Commands.Handlers
{
    public class ExportClothSizeCommandHandler : IRequestHandler<ExportClothSizeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IClothSizeService _service;
        public ExportClothSizeCommandHandler(IClothSizeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportClothSizeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
