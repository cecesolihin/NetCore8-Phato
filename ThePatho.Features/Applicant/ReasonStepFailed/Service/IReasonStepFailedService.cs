using ThePatho.Features.Applicant.ReasonStepFailed.DTO;
using ThePatho.Features.Applicant.ReasonStepFailed.Service;
using ThePatho.Infrastructure.Persistance;

namespace ThePatho.Features.Applicant.ReasonStepFailed.Service
{
    public interface IReasonStepFailedService
    {
        Task<List<ReasonStepFailedDto>> GetAllReasonStepFailedAsync();
        Task<ReasonStepFailedDto?> GetReasonStepFailedByCriteriaAsync(string code);
        Task<ReasonStepFailedDto> AddReasonStepFailedAsync(ReasonStepFailedDto reason);
        Task<ReasonStepFailedDto?> UpdateReasonStepFailedAsync(ReasonStepFailedDto reason);
        Task<bool> DeleteReasonStepFailedAsync(string code);
    }
}