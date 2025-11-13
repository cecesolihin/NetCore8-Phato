using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.JobClass.Commands
{
    public class ExportJobClassCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; } = "excel"; // "excel" or "pdf"
    }
}