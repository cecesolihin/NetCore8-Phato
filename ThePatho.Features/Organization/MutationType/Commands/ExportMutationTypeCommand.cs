using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.MutationType.Commands
{
    public class ExportMutationTypeCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; }
    }
}