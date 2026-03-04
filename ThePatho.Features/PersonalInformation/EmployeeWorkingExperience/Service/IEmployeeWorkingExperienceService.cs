using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Commands;
using ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeWorkingExperience.Service
{
    public interface IEmployeeWorkingExperienceService
    {
        Task<ApiResponse<EmployeeWorkingExperienceItemDto>> GetEmployeeWorkingExperience(GetEmployeeWorkingExperienceCommand request);
        Task<ApiResponse<EmployeeWorkingExperienceItemDto>> GetEmployeeWorkingExperienceByCriteria(GetEmployeeWorkingExperienceByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeWorkingExperience(SubmitEmployeeWorkingExperienceCommand request);
        Task<ApiResponse> DeleteEmployeeWorkingExperience(DeleteEmployeeWorkingExperienceCommand request);

        Task<ApiResponse<EmployeeWorkingExperienceDto>> GetSingleEmployeeWorkingExperience(GetSingleEmployeeWorkingExperienceCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeWorkingExperienceAsync(string type);
    }
}
