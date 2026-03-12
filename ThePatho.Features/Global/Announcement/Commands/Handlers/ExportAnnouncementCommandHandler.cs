using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThePatho.Features.Common.DTO;
using ThePatho.Features.Global.Announcement.Service;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Global.Announcement.Commands.Handlers
{
    public class ExportAnnouncementCommandHandler : IRequestHandler<ExportAnnouncementCommand, ApiResponse<AttachmentFileDto>>
    {
        private readonly IAnnouncementService _service;
        public ExportAnnouncementCommandHandler(IAnnouncementService service)
        {
            _service = service;
        }

        public async Task<ApiResponse<AttachmentFileDto>> Handle(ExportAnnouncementCommand request, CancellationToken cancellationToken)
        {
            return await _service.ExportAsync(request);
        }
    }
}
