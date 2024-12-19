using ThePatho.Features.Applicant.ApplicantAddress.Commands;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;

namespace ThePatho.Features.Applicant.ApplicantAddress.Service
{
    public interface IApplicantAddressService
    {
        Task<List<ApplicantAddressDto>> GetApplicantAddress(GetApplicantAddressCommand request);
        Task<ApplicantAddressDto> GetApplicantAddressByCriteria(GetApplicantAddressByCriteriaCommand request);
    }
}
