using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.TimeZone.Commands;
using ThePatho.Features.Global.TimeZone.DTO;

namespace ThePatho.Features.Global.TimeZone.Service
{
    public interface ITimeZoneService
    {
        Task<ApiResponse<TimeZoneItemDto>> GetTimeZone(GetTimeZoneCommand request);
        Task<ApiResponse<TimeZoneDto>> GetSingleTimeZone(GetSingleTimeZoneCommand request);
        Task<ApiResponse<TimeZoneItemDto>> GetTimeZoneByCriteria(GetTimeZoneByCriteriaCommand request);
        Task<ApiResponse> SubmitTimeZone(SubmitTimeZoneCommand request);
        Task<ApiResponse> DeleteTimeZone(DeleteTimeZoneCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportTimeZoneCommand request);
    }
}

