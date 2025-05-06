using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Commands;
using ThePatho.Provider.ApiResponse;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Service
{
    public interface IRecruitmentRequestService
    {
        Task<ApiResponse<RecruitmentRequestItemDto>> GetRecruitmentRequest(GetRecruitmentRequestCommand request);
        Task<ApiResponse<RecruitmentRequestDto>> GetRecruitmentRequestByCriteria(GetRecruitmentRequestByCriteriaCommand request);
        Task<ApiResponse> SubmitRecruitmentRequest(SubmitRecruitmentRequestCommand request);
        Task<ApiResponse> DeleteRecruitmentRequest(DeleteRecruitmentRequestCommand request);
    }
}
