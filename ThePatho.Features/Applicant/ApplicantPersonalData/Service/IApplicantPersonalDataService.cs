using ThePatho.Features.Applicant.ApplicantPersonalData.Commands;
using ThePatho.Features.Applicant.ApplicantPersonalData.DTO;

namespace ThePatho.Features.Applicant.ApplicantPersonalData.Service
{
    public interface IApplicantPersonalDataService
    {
        Task<List<ApplicantPersonalDataDto>> GetApplicantPersonalData(GetApplicantPersonalDataCommand request);
        Task<ApplicantPersonalDataDto> GetApplicantPersonalDataByCriteria(GetApplicantPersonalDataByCriteriaCommand request); 
    }
}
