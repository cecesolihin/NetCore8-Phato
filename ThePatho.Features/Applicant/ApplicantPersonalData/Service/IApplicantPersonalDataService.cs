using ThePatho.Features.Applicant.ApplicantPersonalData.Commands;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Service
{
    public interface IApplicantPersonalDataService
    {
        Task<ApiResponse<ApplicantPersonalDataItemDto>> GetApplicantPersonalData(GetApplicantPersonalDataCommand request);
        Task<ApiResponse<ApplicantPersonalDataDto>> GetApplicantPersonalDataByCriteria(GetApplicantPersonalDataByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantPersonalData(SubmitApplicantPersonalDataCommand request);
        Task<ApiResponse> DeleteApplicantPersonalData(DeleteApplicantPersonalDataCommand request);
    }
}
