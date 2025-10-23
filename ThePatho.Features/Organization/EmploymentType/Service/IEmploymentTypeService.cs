using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.EmploymentType.Commands;
using ThePatho.Features.Organization.EmploymentType.DTO;

namespace ThePatho.Features.Organization.EmploymentType.Service
{
    public interface IEmploymentTypeService
    {
        Task<ApiResponse<EmploymentTypeItemDto>> GetEmploymentType(GetEmploymentTypeCommand request);
        Task<ApiResponse<EmploymentTypeDto>> GetSingleEmploymentType(GetSingleEmploymentTypeCommand request);
        Task<ApiResponse<EmploymentTypeItemDto>> GetEmploymentTypeByCriteria(GetEmploymentTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitEmploymentType(SubmitEmploymentTypeCommand request);
        Task<ApiResponse> DeleteEmploymentType(DeleteEmploymentTypeCommand request);
    }
}
