using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Commands;
using ThePatho.Features.ConfigurationExtensions;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Service
{
    public interface IRecruitmentRequestService
    {
        Task<NewApiResponse<RecruitmentRequestItemDto>> GetRecruitmentRequest(GetRecruitmentRequestCommand request);
        Task<NewApiResponse<RecruitmentRequestDto>> GetRecruitmentRequestByCriteria(GetRecruitmentRequestByCriteriaCommand request);
        Task<ApiResponse> SubmitRecruitmentRequest(SubmitRecruitmentRequestCommand request);
        Task<ApiResponse> DeleteRecruitmentRequest(DeleteRecruitmentRequestCommand request);
    }
}
