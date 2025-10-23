using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeFamily.Commands;
using ThePatho.Features.PersonalInformation.EmployeeFamily.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeFamily.Service
{
    public interface IEmployeeFamilyService
    {
        Task<ApiResponse<EmployeeFamilyItemDto>> GetEmployeeFamily(GetEmployeeFamilyCommand request);
        Task<ApiResponse<EmployeeFamilyItemDto>> GetEmployeeFamilyByCriteria(GetEmployeeFamilyByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeFamily(SubmitEmployeeFamilyCommand request);
        Task<ApiResponse> DeleteEmployeeFamily(DeleteEmployeeFamilyCommand request);
        Task<ApiResponse<EmployeeFamilyDto>> GetSingleEmployeeFamily(GetSingleEmployeeFamilyCommand request);
    }
}