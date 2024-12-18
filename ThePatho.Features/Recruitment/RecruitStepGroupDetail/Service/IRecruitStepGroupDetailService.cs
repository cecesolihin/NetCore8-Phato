using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.Commands;
using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;
using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service
{
    public interface IRecruitStepGroupDetailService
    {
        Task<List<RecruitStepGroupDetailDto>> GetRecruitStepGroupDetail(GetRecruitStepGroupDetailCommand request);
        Task<List<RecruitStepGroupDetailDto>> GetRecruitStepGroupDetailByCode(GetRecruitStepGroupDetailByCodeCommand request);
    }
}
