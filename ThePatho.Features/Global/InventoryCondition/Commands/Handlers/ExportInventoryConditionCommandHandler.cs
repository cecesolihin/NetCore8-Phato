using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.InventoryCondition.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryCondition.Commands.Handlers
{
    public class ExportInventoryConditionCommandHandler : IRequestHandler<ExportInventoryConditionCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IInventoryConditionService _service;
        public ExportInventoryConditionCommandHandler(IInventoryConditionService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportInventoryConditionCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
