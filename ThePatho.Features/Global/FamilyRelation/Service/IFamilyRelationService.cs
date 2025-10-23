using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.FamilyRelation.Commands;
using ThePatho.Features.Global.FamilyRelation.DTO;

namespace ThePatho.Features.Global.FamilyRelation.Service
{
    public interface IFamilyRelationService
    {
        Task<ApiResponse<FamilyRelationItemDto>> GetFamilyRelation(GetFamilyRelationCommand request);
        Task<ApiResponse<FamilyRelationItemDto>> GetFamilyRelationByCriteria(GetFamilyRelationByCriteriaCommand request);
        Task<ApiResponse> SubmitFamilyRelation(SubmitFamilyRelationCommand request);
        Task<ApiResponse> DeleteFamilyRelation(DeleteFamilyRelationCommand request);

        Task<ApiResponse<FamilyRelationDto>> GetSingleFamilyRelation(GetSingleFamilyRelationCommand request);
    }
}
