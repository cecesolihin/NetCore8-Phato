using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.InventoryType.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryType.Commands.Handlers
{
    public class ExportInventoryTypeCommandHandler : IRequestHandler<ExportInventoryTypeCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IInventoryTypeService _service;
        public ExportInventoryTypeCommandHandler(IInventoryTypeService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportInventoryTypeCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
