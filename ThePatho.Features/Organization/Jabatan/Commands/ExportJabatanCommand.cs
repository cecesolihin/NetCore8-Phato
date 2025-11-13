using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class ExportJabatanCommand : IRequest<ApiResponse<AttachmentFileDto>>
    {
        public string Type { get; set; }
    }
}