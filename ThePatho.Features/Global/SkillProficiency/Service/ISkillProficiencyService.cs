using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.SkillProficiency.Commands;
using ThePatho.Features.Global.SkillProficiency.DTO;

namespace ThePatho.Features.Global.SkillProficiency.Service
{
    public interface ISkillProficiencyService
    {
        Task<ApiResponse<SkillProficiencyItemDto>> GetSkillProficiency(GetSkillProficiencyCommand request);
        Task<ApiResponse<SkillProficiencyDto>> GetSingleSkillProficiency(GetSingleSkillProficiencyCommand request);
        Task<ApiResponse<SkillProficiencyItemDto>> GetSkillProficiencyByCriteria(GetSkillProficiencyByCriteriaCommand request);
        Task<ApiResponse> SubmitSkillProficiency(SubmitSkillProficiencyCommand request);
        Task<ApiResponse> DeleteSkillProficiency(DeleteSkillProficiencyCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportSkillProficiencyCommand request);
    }
}

