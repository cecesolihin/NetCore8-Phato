using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Rank.Commands
{
    public class ExportRankCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; } = "excel"; // "excel" or "pdf"
    }
}