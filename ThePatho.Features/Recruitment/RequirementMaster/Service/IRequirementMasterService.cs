using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Commands;
using ThePatho.Features.ConfigurationExtensions;
namespace ThePatho.Features.Recruitment.RequirementMaster.Service
{
    public interface IRequirementMasterService 
    {
        Task<NewApiResponse<RequirementMasterItemDto>> GetRequirementMaster(GetRequirementMasterCommand request);
        Task<NewApiResponse<RequirementMasterItemDto>> GetRequirementMasterByCriteria(GetRequirementMasterByCriteriaCommand request);
        Task<ApiResponse> SubmitRequirementMaster(SubmitRequirementMasterCommand request);
        Task<ApiResponse> DeleteRequirementMaster(DeleteRequirementMasterCommand request);
    }
}
