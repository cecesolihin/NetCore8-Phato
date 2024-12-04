using ThePatho.Features.Recruitment.RecruitStep.DTO;

namespace ThePatho.Features.Recruitment.RecruitStep.Service
{
    public interface IRecruitStepService
    {
        Task<List<RecruitStepDto>> GetAllRecruitStepAsync();
        Task<RecruitStepDto?> GetRecruitStepByCodeAsync(string code);
        Task<RecruitStepDto> AddRecruitStepAsync(RecruitStepDto recruitStep);
        Task<RecruitStepDto?> UpdateRecruitStepAsync(RecruitStepDto recruitStep);
        Task<bool> DeleteRecruitStepAsync(string code);
    }
}