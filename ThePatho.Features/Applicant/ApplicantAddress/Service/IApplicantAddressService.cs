using ThePatho.Features.Applicant.ApplicantAddress.Commands;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.ApplicantAddress.Service
{
    public interface IApplicantAddressService
    {
        Task<NewApiResponse<ApplicantAddressItemDto>> GetApplicantAddress(GetApplicantAddressCommand request); 
        Task<NewApiResponse<ApplicantAddressDto>> GetApplicantAddressByCriteria(GetApplicantAddressByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantAddress(SubmitApplicantAddressCommand request);
        Task<ApiResponse> DeleteApplicantAddress(DeleteApplicantAddressCommand request);
    }
}
