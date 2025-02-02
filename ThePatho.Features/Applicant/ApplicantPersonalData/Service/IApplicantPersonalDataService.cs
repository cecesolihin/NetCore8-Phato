using ThePatho.Features.Applicant.ApplicantPersonalData.Commands;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Service
{
    public interface IApplicantPersonalDataService
    {
        Task<NewApiResponse<ApplicantPersonalDataItemDto>> GetApplicantPersonalData(GetApplicantPersonalDataCommand request);
        Task<NewApiResponse<ApplicantPersonalDataDto>> GetApplicantPersonalDataByCriteria(GetApplicantPersonalDataByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantPersonalData(SubmitApplicantPersonalDataCommand request);
        Task<ApiResponse> DeleteApplicantPersonalData(DeleteApplicantPersonalDataCommand request);
    }
}
