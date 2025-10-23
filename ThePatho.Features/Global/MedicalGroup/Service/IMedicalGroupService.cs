using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.MedicalGroup.Commands;
using ThePatho.Features.Global.MedicalGroup.DTO;

namespace ThePatho.Features.Global.MedicalGroup.Service
{
    public interface IMedicalGroupService
    {
        Task<ApiResponse<MedicalGroupItemDto>> GetMedicalGroup(GetMedicalGroupCommand request);
        Task<ApiResponse<MedicalGroupDto>> GetSingleMedicalGroup(GetSingleMedicalGroupCommand request);
        Task<ApiResponse<MedicalGroupItemDto>> GetMedicalGroupByCriteria(GetMedicalGroupByCriteriaCommand request);
        Task<ApiResponse> SubmitMedicalGroup(SubmitMedicalGroupCommand request);
        Task<ApiResponse> DeleteMedicalGroup(DeleteMedicalGroupCommand request);
    }
}
