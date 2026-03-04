using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeEducation.Commands;
using ThePatho.Features.PersonalInformation.EmployeeEducation.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeEducation.Service
{
    public interface IEmployeeEducationService
    {
        Task<ApiResponse<EmployeeEducationItemDto>> GetEmployeeEducation(GetEmployeeEducationCommand request);
        Task<ApiResponse<EmployeeEducationItemDto>> GetEmployeeEducationByCriteria(GetEmployeeEducationByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeEducation(SubmitEmployeeEducationCommand request);
        Task<ApiResponse> DeleteEmployeeEducation(DeleteEmployeeEducationCommand request);
        Task<ApiResponse<EmployeeEducationDto>> GetSingleEmployeeEducation(GetSingleEmployeeEducationCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeEducationAsync(string type);
    }
}