using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Recruitment.RequirementRecRequest.Commands;
using ThePatho.Features.Recruitment.RequirementRecRequest.DTO;
using ThePatho.Provider.ApiResponse;
namespace ThePatho.Features.Recruitment.RequirementRecRequest.Service
{
    public interface IRequirementRecRequestService
    {
        Task<ApiResponse<RequirementRecRequestItemDto>> GetRequirementRecRequest(GetRequirementRecRequestCommand request);
        Task<ApiResponse<RequirementRecRequestItemDto>> GetRequirementRecRequestByCriteria(GetRequirementRecRequestByCriteriaCommand request);
    }
}
