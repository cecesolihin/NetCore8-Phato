using ThePatho.Features.Applicant.ApplicantAddress.DTO;

namespace ThePatho.Features.Applicant.ApplicantAddress.Service
{
    public interface IApplicantAddressService
    {
        Task<List<ApplicantAddressDto>> GetAllApplicantAddressesAsync();
        Task<ApplicantAddressDto?> GetApplicantAddressByCodeAsync(string code);
        Task<ApplicantAddressDto> AddApplicantAddressAsync(ApplicantAddressDto address);
        Task<ApplicantAddressDto?> UpdateApplicantAddressAsync(ApplicantAddressDto address);
        Task<bool> DeleteApplicantAddressAsync(string code);
    }
}
