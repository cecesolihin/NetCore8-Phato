using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Announcement.Commands;
using ThePatho.Features.Global.Announcement.DTO;

namespace ThePatho.Features.Global.Announcement.Service
{
    public interface IAnnouncementService
    {
        Task<ApiResponse<AnnouncementItemDto>> GetAnnouncement(GetAnnouncementCommand request);
        Task<ApiResponse<AnnouncementDto>> GetSingleAnnouncement(GetSingleAnnouncementCommand request);
        Task<ApiResponse<AnnouncementItemDto>> GetAnnouncementByCriteria(GetAnnouncementByCriteriaCommand request);
        Task<ApiResponse> SubmitAnnouncement(SubmitAnnouncementCommand request);
        Task<ApiResponse> DeleteAnnouncement(DeleteAnnouncementCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportAnnouncementCommand request);
    }
}

