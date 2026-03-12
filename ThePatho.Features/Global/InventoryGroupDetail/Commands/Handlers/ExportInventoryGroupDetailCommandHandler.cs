using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.InventoryGroupDetail.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroupDetail.Commands.Handlers
{
    public class ExportInventoryGroupDetailCommandHandler : IRequestHandler<ExportInventoryGroupDetailCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IInventoryGroupDetailService _service;
        public ExportInventoryGroupDetailCommandHandler(IInventoryGroupDetailService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportInventoryGroupDetailCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
