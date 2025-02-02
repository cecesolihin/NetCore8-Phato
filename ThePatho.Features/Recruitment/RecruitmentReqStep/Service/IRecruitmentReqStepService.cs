using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Commands;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Service
{
    public interface IRecruitmentReqStepService 
    {
        Task<NewApiResponse<RecruitmentReqStepItemDto>> GetRecruitmentReqStep(GetRecruitmentReqStepCommand request);
        Task<NewApiResponse<RecruitmentReqStepItemDto>> GetRecruitmentReqStepByCriteria(GetRecruitmentReqStepByCriteriaCommand request);
    }
}
