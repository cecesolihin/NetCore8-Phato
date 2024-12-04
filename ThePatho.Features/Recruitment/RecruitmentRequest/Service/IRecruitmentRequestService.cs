using ThePatho.Features.Recruitment.RecruitmentRequest.DTO;

namespace ThePatho.Features.Recruitment.RecruitmentRequest.Service
{
    public interface IRecruitmentRequestService
    {
        Task<List<RecruitmentRequestDto>> GetAllRecruitmentRequestAsync();
        Task<RecruitmentRequestDto?> GetRecruitmentRequestByCodeAsync(string code);
        Task<RecruitmentRequestDto> AddRecruitmentRequestAsync(RecruitmentRequestDto request);
        Task<RecruitmentRequestDto?> UpdateRecruitmentRequestAsync(RecruitmentRequestDto request);
        Task<bool> DeleteRecruitmentRequestAsync(string code);
    }
}
