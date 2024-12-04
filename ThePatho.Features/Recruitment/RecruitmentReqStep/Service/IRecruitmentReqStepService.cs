using ThePatho.Features.Recruitment.RecruitmentReqStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentReqStep.Service
{
    public interface IRecruitmentReqStepService
    {
        Task<List<RecruitmentReqStepDto>> GetAllRecruitmentReqStepAsync();
        Task<RecruitmentReqStepDto?> GetRecruitmentReqStepByCodeAsync(string code);
        Task<RecruitmentReqStepDto> AddRecruitmentReqStepAsync(RecruitmentReqStepDto reqStep);
        Task<RecruitmentReqStepDto?> UpdateRecruitmentReqStepAsync(RecruitmentReqStepDto reqStep);
        Task<bool> DeleteRecruitmentReqStepAsync(string code);
    }
}
