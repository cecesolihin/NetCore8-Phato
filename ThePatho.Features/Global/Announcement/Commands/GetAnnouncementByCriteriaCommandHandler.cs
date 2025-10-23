using MediatR;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.DTO;
using ThePatho.Features.Global.Announcement.Service;

namespace ThePatho.Features.Global.Announcement.Commands
{
    public class GetAnnouncementByCriteriaCommandHandler : IRequestHandler<GetAnnouncementByCriteriaCommand, ApiResponse<AnnouncementItemDto>>
    {
        private readonly IAnnouncementService announcementService;
        public GetAnnouncementByCriteriaCommandHandler(IAnnouncementService _announcementService)
        {
            announcementService = _announcementService;
        }
        public async Task<ApiResponse<AnnouncementItemDto>> Handle(GetAnnouncementByCriteriaCommand request, CancellationToken cancellationToken)
        {
            return await announcementService.GetAnnouncementByCriteria(request);
        }
    }
}
