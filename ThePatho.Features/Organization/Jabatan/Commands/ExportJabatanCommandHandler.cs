using MediatR;
using ThePatho.Features.Organization.Jabatan.Service;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.Jabatan.Commands
{
    public class ExportJabatanCommandHandler : IRequestHandler<ExportJabatanCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IJabatanService jabatanService;

        public ExportJabatanCommandHandler(IJabatanService _jabatanService)
        {
            jabatanService = _jabatanService;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportJabatanCommand request, CancellationToken cancellationToken)
        {
            return await jabatanService.ExportJabatanAsync(request.Type);
        }
    }
}