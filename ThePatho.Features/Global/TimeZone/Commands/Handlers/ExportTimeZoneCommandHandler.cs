using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.TimeZone.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.TimeZone.Commands.Handlers
{
    public class ExportTimeZoneCommandHandler : IRequestHandler<ExportTimeZoneCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly ITimeZoneService _service;
        public ExportTimeZoneCommandHandler(ITimeZoneService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportTimeZoneCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
