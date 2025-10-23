using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Commands;
using ThePatho.Features.PersonalInformation.EmployeeCareerHistory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeCareerHistory.Service
{
    public interface IEmployeeCareerHistoryService
    {
        Task<ApiResponse<EmployeeCareerHistoryItemDto>> GetEmployeeCareerHistory(GetEmployeeCareerHistoryCommand request);
        Task<ApiResponse<EmployeeCareerHistoryItemDto>> GetEmployeeCareerHistoryByCriteria(GetEmployeeCareerHistoryByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeCareerHistory(SubmitEmployeeCareerHistoryCommand request);
        Task<ApiResponse> DeleteEmployeeCareerHistory(DeleteEmployeeCareerHistoryCommand request);
        Task<ApiResponse<EmployeeCareerHistoryDto>> GetSingleEmployeeCareerHistory(GetSingleEmployeeCareerHistoryCommand request);
    }
}
