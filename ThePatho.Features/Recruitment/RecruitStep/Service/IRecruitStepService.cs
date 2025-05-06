
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Service
{
    public interface IRecruitStepService
    {
        Task<ApiResponse<RecruitStepItemDto>> GetRecruitStep(GetRecruitStepCommand request);
        Task<ApiResponse<RecruitStepDto>> GetRecruitStepByCriteria(GetRecruitStepByCriteriaCommand request);
        Task<ApiResponse> SubmitRecruitStep(SubmitRecruitStepCommand request);
        Task<ApiResponse> DeleteRecruitStep(DeleteRecruitStepCommand request);
    }
}