using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeInventory.Commands;
using ThePatho.Features.PersonalInformation.EmployeeInventory.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeInventory.Service
{
    public interface IEmployeeInventoryService
    {
        Task<ApiResponse<EmployeeInventoryItemDto>> GetEmployeeInventory(GetEmployeeInventoryCommand request);
        Task<ApiResponse<EmployeeInventoryItemDto>> GetEmployeeInventoryByCriteria(GetEmployeeInventoryByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeInventory(SubmitEmployeeInventoryCommand request);
        Task<ApiResponse> DeleteEmployeeInventory(DeleteEmployeeInventoryCommand request);
        Task<ApiResponse<EmployeeInventoryDto>> GetSingleEmployeeInventory(GetSingleEmployeeInventoryCommand request);
    }
}
