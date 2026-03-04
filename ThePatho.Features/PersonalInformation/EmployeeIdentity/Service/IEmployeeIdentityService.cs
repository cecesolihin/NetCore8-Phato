using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.Commands;
using ThePatho.Features.PersonalInformation.EmployeeIdentity.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeIdentity.Service
{
    public interface IEmployeeIdentityService
    {
        Task<ApiResponse<EmployeeIdentityItemDto>> GetEmployeeIdentity(GetEmployeeIdentityCommand request);
        Task<ApiResponse<EmployeeIdentityItemDto>> GetEmployeeIdentityByCriteria(GetEmployeeIdentityByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeIdentity(SubmitEmployeeIdentityCommand request);
        Task<ApiResponse> DeleteEmployeeIdentity(DeleteEmployeeIdentityCommand request);
        Task<ApiResponse<EmployeeIdentityDto>> GetSingleEmployeeIdentity(GetSingleEmployeeIdentityCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeIdentityAsync(string type);
    }
}
