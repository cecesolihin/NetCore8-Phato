using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Commands;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Service
{
    public interface IRecruitmentReqStepService 
    {
        Task<List<RecruitmentReqStepDto>> GetRecruitmentReqStep(GetRecruitmentReqStepCommand request);
        Task<List<RecruitmentReqStepDto>> GetRecruitmentReqStepByCriteria(GetRecruitmentReqStepByCriteriaCommand request);
    }
}
