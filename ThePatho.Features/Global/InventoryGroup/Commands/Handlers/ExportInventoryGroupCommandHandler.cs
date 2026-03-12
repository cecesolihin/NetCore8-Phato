using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.InventoryGroup.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroup.Commands.Handlers
{
    public class ExportInventoryGroupCommandHandler : IRequestHandler<ExportInventoryGroupCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IInventoryGroupService _service;
        public ExportInventoryGroupCommandHandler(IInventoryGroupService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportInventoryGroupCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
