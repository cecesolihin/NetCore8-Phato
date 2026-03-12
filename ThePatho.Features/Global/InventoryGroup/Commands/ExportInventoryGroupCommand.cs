using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.InventoryGroup.Commands
{
    public class ExportInventoryGroupCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; } = "excel"; // "excel" or "pdf"
    }
}
