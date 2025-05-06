using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;
using ThePatho.Features.Recruitment.RecruitmentReqStep.Commands;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Service
{
    public interface IRecruitmentReqStepService 
    {
        Task<ApiResponse<RecruitmentReqStepItemDto>> GetRecruitmentReqStep(GetRecruitmentReqStepCommand request);
        Task<ApiResponse<RecruitmentReqStepItemDto>> GetRecruitmentReqStepByCriteria(GetRecruitmentReqStepByCriteriaCommand request);
    }
}
