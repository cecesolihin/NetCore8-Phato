using ThePatho.Provider.ApiResponse;
using ThePatho.Features.PersonalInformation.EmployeePunishment.Commands;
using ThePatho.Features.PersonalInformation.EmployeePunishment.DTO;

namespace ThePatho.Features.PersonalInformation.EmployeePunishment.Service
{
    public interface IEmployeePunishmentService
    {
        Task<ApiResponse<EmployeePunishmentItemDto>> GetEmployeePunishment(GetEmployeePunishmentCommand request);
        Task<ApiResponse<EmployeePunishmentItemDto>> GetEmployeePunishmentByCriteria(GetEmployeePunishmentByCriteriaCommand request);
        Task<ApiResponse> SubmitEmployeePunishment(SubmitEmployeePunishmentCommand request);
        Task<ApiResponse> DeleteEmployeePunishment(DeleteEmployeePunishmentCommand request);
        Task<ApiResponse<EmployeePunishmentDto>> GetSingleEmployeePunishment(GetSingleEmployeePunishmentCommand request);
    }   
}
