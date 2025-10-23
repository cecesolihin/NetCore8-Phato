using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.DTO;
using ThePatho.Features.Global.Announcement.Service;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class GetAnnouncementCommandHandler : IRequestHandler<GetAnnouncementCommand, ApiResponse<AnnouncementItemDto>>
    {
        private readonly IAnnouncementService announcementService;
        public GetAnnouncementCommandHandler(IAnnouncementService _announcementService)
        {
            announcementService = _announcementService;
        }
        public async Task<ApiResponse<AnnouncementItemDto>> Handle(GetAnnouncementCommand request, CancellationToken cancellationToken)
        {
            return await announcementService.GetAnnouncement(request);
        }
    }
}
