using ThePatho.Features.Recruitment.RequirementRecRequest.Commands;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Service
{
    public interface IRequirementRecRequestService
    {
        Task<List<RequirementRecRequestDto>> GetRequirementRecRequest(GetRequirementRecRequestCommand request);
        Task<List<RequirementRecRequestDto>> GetRequirementRecRequestByCriteria(GetRequirementRecRequestByCriteriaCommand request);
    }
}
