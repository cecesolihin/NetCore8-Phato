using ThePatho.Features.Recruitment.RecruitStepGroup.DTO;

namespace ThePatho.Features.Recruitment.RecruitStepGroup.Service
{
    public interface IRecruitStepGroupService
    {
        Task<List<RecruitStepGroupDto>> GetAllRecruitStepGroupAsync();
        Task<RecruitStepGroupDto?> GetRecruitStepGroupByCodeAsync(string code);
        Task<RecruitStepGroupDto> AddRecruitStepGroupAsync(RecruitStepGroupDto recruitStepGroup);
        Task<RecruitStepGroupDto?> UpdateRecruitStepGroupAsync(RecruitStepGroupDto recruitStepGroup);
        Task<bool> DeleteRecruitStepGroupAsync(string code);
    }
}
