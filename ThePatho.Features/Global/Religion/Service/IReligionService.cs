using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Religion.Commands;
using ThePatho.Features.Global.Religion.DTO;

namespace ThePatho.Features.Global.Religion.Service
{
    public interface IReligionService
    {
        Task<ApiResponse<ReligionItemDto>> GetReligion(GetReligionCommand request);
        Task<ApiResponse<ReligionDto>> GetSingleReligion(GetSingleReligionCommand request);
        Task<ApiResponse<ReligionItemDto>> GetReligionByCriteria(GetReligionByCriteriaCommand request);
        Task<ApiResponse> SubmitReligion(SubmitReligionCommand request);
        Task<ApiResponse> DeleteReligion(DeleteReligionCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportReligionCommand request);

    }
}