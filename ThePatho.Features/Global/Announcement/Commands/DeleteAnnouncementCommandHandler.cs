using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.Service;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class DeleteAnnouncementCommandHandler : IRequestHandler<DeleteAnnouncementCommand, ApiResponse>
    {
        private readonly IAnnouncementService announcementService;

        public DeleteAnnouncementCommandHandler(IAnnouncementService _announcementService)
        {
            announcementService = _announcementService;
        }

        public async Task<ApiResponse> Handle(DeleteAnnouncementCommand request, CancellationToken cancellationToken)
        {
            return await announcementService.DeleteAnnouncement(request);
        }
    }
}
