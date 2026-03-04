using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeTraining.Commands;
using ThePatho.Features.PersonalInformation.EmployeeTraining.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeTraining.Service
{
    public interface IEmployeeTrainingService
    {
        Task<ApiResponse<EmployeeTrainingItemDto>> GetEmployeeTraining(GetEmployeeTrainingCommand request);
        Task<ApiResponse<EmployeeTrainingItemDto>> GetEmployeeTrainingByCriteria(GetEmployeeTrainingByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeTraining(SubmitEmployeeTrainingCommand request);
        Task<ApiResponse> DeleteEmployeeTraining(DeleteEmployeeTrainingCommand request);

        Task<ApiResponse<EmployeeTrainingDto>> GetSingleEmployeeTraining(GetSingleEmployeeTrainingCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeTrainingAsync(string type);
    }
}
