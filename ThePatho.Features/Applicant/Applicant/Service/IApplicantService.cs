using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Commands;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Applicant.Applicant.Service
{
    public interface IApplicantService
    {
        Task<ApiResponse<ApplicantItemDto>> GetApplicant(GetApplicantCommand request);
        Task<ApiResponse<ApplicantDto>> GetApplicantByCriteria(GetApplicantByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicant(SubmitApplicantCommand request);
        Task<ApiResponse> DeleteApplicant(DeleteApplicantCommand request);
    }
}
