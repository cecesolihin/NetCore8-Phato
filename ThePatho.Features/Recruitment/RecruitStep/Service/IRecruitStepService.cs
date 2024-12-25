
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Service
{
    public interface IRecruitStepService
    {
        Task<List<RecruitStepDto>> GetRecruitStep(GetRecruitStepCommand request);
        Task<RecruitStepDto> GetRecruitStepByCriteria(GetRecruitStepByCriteriaCommand request);
    }
}