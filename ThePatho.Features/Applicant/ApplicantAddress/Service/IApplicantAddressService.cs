using ThePatho.Features.Applicant.ApplicantAddress.Commands;
using ThePatho.Features.Applicant.ApplicantAddress.DTO;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.ApplicantAddress.Service
{
    public interface IApplicantAddressService
    {
        Task<ApiResponse<ApplicantAddressItemDto>> GetApplicantAddress(GetApplicantAddressCommand request); 
        Task<ApiResponse<ApplicantAddressDto>> GetApplicantAddressByCriteria(GetApplicantAddressByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicantAddress(SubmitApplicantAddressCommand request);
        Task<ApiResponse> DeleteApplicantAddress(DeleteApplicantAddressCommand request);
    }
}
