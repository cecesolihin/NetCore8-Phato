using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.Employee.Commands;
using ThePatho.Features.PersonalInformation.Employee.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.Employee.Service
{
    public interface IEmployeeService
    {
        Task<ApiResponse<EmployeeItemDto>> GetEmployee(GetEmployeeCommand request);
        Task<ApiResponse<EmployeeItemDto>> GetEmployeeByCriteria(GetEmployeeByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployee(SubmitEmployeeCommand request);
        Task<ApiResponse> DeleteEmployee(DeleteEmployeeCommand request);
        Task<ApiResponse<EmployeeDto>> GetSingleEmployee(GetSingleEmployeeCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeAsync(string type);
    }
}
