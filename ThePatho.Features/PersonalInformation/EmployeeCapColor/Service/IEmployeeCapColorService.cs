using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.Commands;
using ThePatho.Features.PersonalInformation.EmployeeCapColor.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCapColor.Service
{
    public interface IEmployeeCapColorService
    {
        Task<ApiResponse<EmployeeCapColorItemDto>> GetEmployeeCapColor(GetEmployeeCapColorCommand request);
        Task<ApiResponse<EmployeeCapColorItemDto>> GetEmployeeCapColorByCriteria(GetEmployeeCapColorByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeCapColor(SubmitEmployeeCapColorCommand request);
        Task<ApiResponse> DeleteEmployeeCapColor(DeleteEmployeeCapColorCommand request);
        Task<ApiResponse<EmployeeCapColorDto>> GetSingleEmployeeCapColor(GetSingleEmployeeCapColorCommand request);
    }
}
