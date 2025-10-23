using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.Skill.Commands;
using ThePatho.Features.Global.Skill.DTO;

namespace ThePatho.Features.Global.Skill.Service
{
    public interface ISkillService
    {
        Task<ApiResponse<SkillItemDto>> GetSkill(GetSkillCommand request);
        Task<ApiResponse<SkillDto>> GetSingleSkill(GetSingleSkillCommand request);
        Task<ApiResponse<SkillItemDto>> GetSkillByCriteria(GetSkillByCriteriaCommand request);
        Task<ApiResponse> SubmitSkill(SubmitSkillCommand request);
        Task<ApiResponse> DeleteSkill(DeleteSkillCommand request);
    }
}
