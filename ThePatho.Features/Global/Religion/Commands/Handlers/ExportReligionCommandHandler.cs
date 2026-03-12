using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Religion.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Religion.Commands.Handlers
{
    public class ExportReligionCommandHandler : IRequestHandler<ExportReligionCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IReligionService _service;
        public ExportReligionCommandHandler(IReligionService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportReligionCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
