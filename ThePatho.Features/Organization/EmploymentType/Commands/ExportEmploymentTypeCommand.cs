using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.EmploymentType.Commands
{
    public class ExportEmploymentTypeCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; }
    }
}