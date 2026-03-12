using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.InventoryGroupOrg.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroupOrg.Commands.Handlers
{
    public class ExportInventoryGroupOrgCommandHandler : IRequestHandler<ExportInventoryGroupOrgCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IInventoryGroupOrgService _service;
        public ExportInventoryGroupOrgCommandHandler(IInventoryGroupOrgService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportInventoryGroupOrgCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
