using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Service
{
    public interface IApplicantPersonalDataService
    {
        Task<List<ApplicantPersonalDataDto>> GetAllApplicantPersonalDataAsync();
        Task<ApplicantPersonalDataDto?> GetApplicantPersonalDataByCodeAsync(string code);
        Task<ApplicantPersonalDataDto> AddApplicantPersonalDataAsync(ApplicantPersonalDataDto data);
        Task<ApplicantPersonalDataDto?> UpdateApplicantPersonalDataAsync(ApplicantPersonalDataDto data);
        Task<bool> DeleteApplicantPersonalDataAsync(string code);
    }
}
