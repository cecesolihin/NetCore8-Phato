using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStepGroup.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Service
{
    public interface IRecruitStepGroupService
    {
        Task<NewApiResponse<RecruitStepGroupItemDto>> GetRecruitStepGroup(GetRecruitStepGroupCommand request);
        Task<NewApiResponse<RecruitStepGroupDto>> GetRecruitStepGroupByCriteria(GetRecruitStepGroupByCriteriaCommand request);
        Task<ApiResponse> SubmitRecruitStepGroup(SubmitRecruitStepGroupCommand request);
        Task<ApiResponse> DeleteRecruitStepGroup(DeleteRecruitStepGroupCommand request);
    }
}
