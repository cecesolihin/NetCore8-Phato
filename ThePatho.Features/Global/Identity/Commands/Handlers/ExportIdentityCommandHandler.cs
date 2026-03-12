using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Identity.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Identity.Commands.Handlers
{
    public class ExportIdentityCommandHandler : IRequestHandler<ExportIdentityCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IIdentityService _service;
        public ExportIdentityCommandHandler(IIdentityService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportIdentityCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
