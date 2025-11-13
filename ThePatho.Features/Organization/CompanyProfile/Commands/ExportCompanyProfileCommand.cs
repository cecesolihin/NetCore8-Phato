using MediatR;
using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Organization.CompanyProfile.Commands
{
    public class ExportCompanyProfileCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; } = "excel"; // "excel" or "pdf"
    }
}