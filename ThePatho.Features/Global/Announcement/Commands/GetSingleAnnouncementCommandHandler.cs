using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.DTO;
using ThePatho.Features.Global.Announcement.Service;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class GetSingleAnnouncementCommandHandler : IRequestHandler<GetSingleAnnouncementCommand, ApiResponse<AnnouncementDto>>
    {
        private readonly IAnnouncementService announcementService;
        public GetSingleAnnouncementCommandHandler(IAnnouncementService _announcementService)
        {
            announcementService = _announcementService;
        }
        public async Task<ApiResponse<AnnouncementDto>> Handle(GetSingleAnnouncementCommand request, CancellationToken cancellationToken)
        {
            return await announcementService.GetSingleAnnouncement(request);
        }
    }
}
