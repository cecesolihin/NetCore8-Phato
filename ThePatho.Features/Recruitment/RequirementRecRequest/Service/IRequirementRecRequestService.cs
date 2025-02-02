using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Recruitment.RequirementRecRequest.Commands;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;

namespace ThePatho.Features.Recruitment.RequirementRecRequest.Service
{
    public interface IRequirementRecRequestService
    {
        Task<NewApiResponse<RequirementRecRequestItemDto>> GetRequirementRecRequest(GetRequirementRecRequestCommand request);
        Task<NewApiResponse<RequirementRecRequestItemDto>> GetRequirementRecRequestByCriteria(GetRequirementRecRequestByCriteriaCommand request);
    }
}
