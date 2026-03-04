using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeeReward.Commands;
using ThePatho.Features.PersonalInformation.EmployeeReward.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeeReward.Service
{
    public interface IEmployeeRewardService
    {
        Task<ApiResponse<EmployeeRewardItemDto>> GetEmployeeReward(GetEmployeeRewardCommand request);
        Task<ApiResponse<EmployeeRewardItemDto>> GetEmployeeRewardByCriteria(GetEmployeeRewardByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeeReward(SubmitEmployeeRewardCommand request);
        Task<ApiResponse> DeleteEmployeeReward(DeleteEmployeeRewardCommand request);

        Task<ApiResponse<EmployeeRewardDto>> GetSingleEmployeeReward(GetSingleEmployeeRewardCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportEmployeeRewardAsync(string type);
    }
}
