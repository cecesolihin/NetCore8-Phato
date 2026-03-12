using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Nationality.Commands;
using ThePatho.Features.Global.Nationality.DTO;

namespace ThePatho.Features.Global.Nationality.Service
{
    public interface INationalityService
    {
        Task<ApiResponse<NationalityItemDto>> GetNationality(GetNationalityCommand request);
        Task<ApiResponse<NationalityDto>> GetSingleNationality(GetSingleNationalityCommand request);
        Task<ApiResponse<NationalityItemDto>> GetNationalityByCriteria(GetNationalityByCriteriaCommand request);
        Task<ApiResponse> SubmitNationality(SubmitNationalityCommand request);
        Task<ApiResponse> DeleteNationality(DeleteNationalityCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportNationalityCommand request);
    }
}

