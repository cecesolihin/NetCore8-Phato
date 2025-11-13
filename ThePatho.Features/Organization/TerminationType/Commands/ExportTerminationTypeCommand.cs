using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.TerminationType.Commands
{
    public class ExportTerminationTypeCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; } = "excel"; // "excel" or "pdf"
    }
}