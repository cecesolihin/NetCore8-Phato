
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RecruitStep.Commands;
using ThePatho.Features.Recruitment.RecruitStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Service
{
    public interface IRecruitStepService
    {
        Task<NewApiResponse<RecruitStepItemDto>> GetRecruitStep(GetRecruitStepCommand request);
        Task<NewApiResponse<RecruitStepDto>> GetRecruitStepByCriteria(GetRecruitStepByCriteriaCommand request);
        Task<ApiResponse> SubmitRecruitStep(SubmitRecruitStepCommand request);
        Task<ApiResponse> DeleteRecruitStep(DeleteRecruitStepCommand request);
    }
}