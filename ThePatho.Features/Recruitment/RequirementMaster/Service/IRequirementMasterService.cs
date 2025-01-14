using ThePatho.Features.Recruitment.RequirementMaster.DTO;
using ThePatho.Features.Recruitment.RequirementMaster.Commands;
namespace ThePatho.Features.Recruitment.RequirementMaster.Service
{
    public interface IRequirementMasterService 
    {
        Task<List<RequirementMasterDto>> GetRequirementMaster(GetRequirementMasterCommand request);
        Task<List<RequirementMasterDto>> GetRequirementMasterByCriteria(GetRequirementMasterByCriteriaCommand request);
        Task<bool> SubmitRequirementMaster(SubmitRequirementMasterCommand request);
        Task<bool> DeleteRequirementMaster(DeleteRequirementMasterCommand request);
    }
}
