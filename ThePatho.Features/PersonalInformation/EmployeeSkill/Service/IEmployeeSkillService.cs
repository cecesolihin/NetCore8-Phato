using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeSkill.Commands;
using ThePatho.Features.PersonalInformation.EmployeeSkill.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeSkill.Service
{
    public interface IEmployeeSkillService
    {
        Task<ApiResponse<EmployeeSkillItemDto>> GetEmployeeSkill(GetEmployeeSkillCommand request);
        Task<ApiResponse<EmployeeSkillItemDto>> GetEmployeeSkillByCriteria(GetEmployeeSkillByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeSkill(SubmitEmployeeSkillCommand request);
        Task<ApiResponse> DeleteEmployeeSkill(DeleteEmployeeSkillCommand request);

        Task<ApiResponse<EmployeeSkillDto>> GetSingleEmployeeSkill(GetSingleEmployeeSkillCommand request);
    }
}