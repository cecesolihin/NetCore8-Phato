using ThePatho.Features.Applicant.Applicant.DTO;
using ThePatho.Features.Applicant.Applicant.Commands;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Applicant.Applicant.Service
{
    public interface IApplicantService
    {
        Task<NewApiResponse<ApplicantItemDto>> GetApplicant(GetApplicantCommand request);
        Task<NewApiResponse<ApplicantDto>> GetApplicantByCriteria(GetApplicantByCriteriaCommand request);
        Task<ApiResponse> SubmitApplicant(SubmitApplicantCommand request);
        Task<ApiResponse> DeleteApplicant(DeleteApplicantCommand request);
    }
}
