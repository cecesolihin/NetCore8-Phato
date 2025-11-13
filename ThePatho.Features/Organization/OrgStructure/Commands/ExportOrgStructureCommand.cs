using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Commands
{
    public class ExportOrgStructureCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; }
    }
}