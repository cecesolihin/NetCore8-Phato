using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Commands;
using ThePatho.Provider.ApiResponse;
namespace ThePatho.Features.Recruitment.RequirementMaster.Service
{
    public interface IRequirementMasterService 
    {
        Task<ApiResponse<RequirementMasterItemDto>> GetRequirementMaster(GetRequirementMasterCommand request);
        Task<ApiResponse<RequirementMasterItemDto>> GetRequirementMasterByCriteria(GetRequirementMasterByCriteriaCommand request);
        Task<ApiResponse> SubmitRequirementMaster(SubmitRequirementMasterCommand request);
        Task<ApiResponse> DeleteRequirementMaster(DeleteRequirementMasterCommand request);
    }
}
