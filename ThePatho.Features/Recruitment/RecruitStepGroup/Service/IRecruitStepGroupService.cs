using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStepGroup.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Service
{
    public interface IRecruitStepGroupService
    {
        Task<ApiResponse<RecruitStepGroupItemDto>> GetRecruitStepGroup(GetRecruitStepGroupCommand request);
        Task<ApiResponse<RecruitStepGroupDto>> GetRecruitStepGroupByCriteria(GetRecruitStepGroupByCriteriaCommand request);
        Task<ApiResponse> SubmitRecruitStepGroup(SubmitRecruitStepGroupCommand request);
        Task<ApiResponse> DeleteRecruitStepGroup(DeleteRecruitStepGroupCommand request);
    }
}
