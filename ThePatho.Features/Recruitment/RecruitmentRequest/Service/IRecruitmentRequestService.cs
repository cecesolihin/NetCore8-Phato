using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;
using ThePatho.Features.Recruitment.RecruitmentRequest.Commands;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Service
{
    public interface IRecruitmentRequestService
    {
        Task<List<RecruitmentRequestDto>> GetRecruitmentRequest(GetRecruitmentRequestCommand request);
        Task<RecruitmentRequestDto> GetRecruitmentRequestByCriteria(GetRecruitmentRequestByCriteriaCommand request);
    }
}
