using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.GraduationType.Commands;
using ThePatho.Features.Global.GraduationType.DTO;

namespace ThePatho.Features.Global.GraduationType.Service
{
    public interface IGraduationTypeService
    {
        Task<ApiResponse<GraduationTypeItemDto>> GetGraduationType(GetGraduationTypeCommand request);
        Task<ApiResponse<GraduationTypeDto>> GetSingleGraduationType(GetSingleGraduationTypeCommand request);
        Task<ApiResponse<GraduationTypeItemDto>> GetGraduationTypeByCriteria(GetGraduationTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitGraduationType(SubmitGraduationTypeCommand request);
        Task<ApiResponse> DeleteGraduationType(DeleteGraduationTypeCommand request);
    }
}
