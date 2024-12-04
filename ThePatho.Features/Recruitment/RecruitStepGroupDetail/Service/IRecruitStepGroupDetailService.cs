using ThePatho.Features.Recruitment.RecruitStepGroupDetail.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroupDetail.Service
{
    public interface IRecruitStepGroupDetailService
    {
        Task<List<RecruitStepGroupDetailDto>> GetAllRecruitStepGroupDetailAsync();
        Task<RecruitStepGroupDetailDto?> GetRecruitStepGroupDetailByCodeAsync(string code);
        Task<RecruitStepGroupDetailDto> AddRecruitStepGroupDetailAsync(RecruitStepGroupDetailDto detail);
        Task<RecruitStepGroupDetailDto?> UpdateRecruitStepGroupDetailAsync(RecruitStepGroupDetailDto detail);
        Task<bool> DeleteRecruitStepGroupDetailAsync(string code);
    }
}
