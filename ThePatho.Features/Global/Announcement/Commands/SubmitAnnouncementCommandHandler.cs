using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.Service;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class SubmitAnnouncementCommandHandler : IRequestHandler<SubmitAnnouncementCommand, ApiResponse>
    {
        private readonly IAnnouncementService announcementService;

        public SubmitAnnouncementCommandHandler(IAnnouncementService _announcementService)
        {
            announcementService = _announcementService;
        }

        public async Task<ApiResponse> Handle(SubmitAnnouncementCommand request, CancellationToken cancellationToken)
        {
            return await announcementService.SubmitAnnouncement(request);
        }
    }
}
