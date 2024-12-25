using ThePatho.Features.Recruitment.RecruitStepGroup.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Service
{
    public interface IRecruitStepGroupService
    {
        Task<List<RecruitStepGroupDto>> GetRecruitStepGroup(GetRecruitStepGroupCommand request);
        Task<RecruitStepGroupDto> GetRecruitStepGroupByCriteria(GetRecruitStepGroupByCriteriaCommand request);
    }
}
