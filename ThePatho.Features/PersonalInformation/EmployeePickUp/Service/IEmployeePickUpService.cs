using ThePatho.Provider.ApiResponse;

using ThePatho.Features.PersonalInformation.EmployeePickUp.DTO;
using ThePatho.Features.PersonalInformation.EmployeePickUp.Commands;

namespace ThePatho.Features.PersonalInformation.EmployeePickUp.Service
{
    public interface IEmployeePickUpService
    {
        Task<ApiResponse<EmployeePickUpItemDto>> GetEmployeePickUp(GetEmployeePickUpCommand request);
        Task<ApiResponse<EmployeePickUpItemDto>> GetEmployeePickUpByCriteria(GetEmployeePickUpByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeePickUp(SubmitEmployeePickUpCommand request);
        Task<ApiResponse> DeleteEmployeePickUp(DeleteEmployeePickUpCommand request);
        Task<ApiResponse<EmployeePickUpDto>> GetSingleEmployeePickUp(GetSingleEmployeePickUpCommand request);
    }   
}
