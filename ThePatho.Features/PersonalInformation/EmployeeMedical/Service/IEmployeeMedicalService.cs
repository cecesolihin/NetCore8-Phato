using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeMedical.Commands;
using ThePatho.Features.PersonalInformation.EmployeeMedical.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeMedical.Service
{
    public interface IEmployeeMedicalService
    {
        Task<ApiResponse<EmployeeMedicalItemDto>> GetEmployeeMedical(GetEmployeeMedicalCommand request);
        Task<ApiResponse<EmployeeMedicalItemDto>> GetEmployeeMedicalByCriteria(GetEmployeeMedicalByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeMedical(SubmitEmployeeMedicalCommand request);
        Task<ApiResponse> DeleteEmployeeMedical(DeleteEmployeeMedicalCommand request);
        Task<ApiResponse<EmployeeMedicalDto>> GetSingleEmployeeMedical(GetSingleEmployeeMedicalCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeMedicalAsync(string type);
    }
}
