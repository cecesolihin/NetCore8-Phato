using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CostCenter.Commands
{
    public class ExportCostCenterCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; } = "excel"; // "excel" or "pdf"
    }
}