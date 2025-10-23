using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocationGroup.Commands;
using ThePatho.Features.Organization.WorkLocationGroup.DTO;

namespace ThePatho.Features.Organization.WorkLocationGroup.Service
{
    public interface IWorkLocationGroupService
    {
        Task<ApiResponse<WorkLocationGroupItemDto>> GetWorkLocationGroup(GetWorkLocationGroupCommand request);
        Task<ApiResponse<WorkLocationGroupDto>> GetSingleWorkLocationGroup(GetSingleWorkLocationGroupCommand request);
        Task<ApiResponse<WorkLocationGroupItemDto>> GetWorkLocationGroupByCriteria(GetWorkLocationGroupByCriteriaCommand request);
        Task<ApiResponse> SubmitWorkLocationGroup(SubmitWorkLocationGroupCommand request);
        Task<ApiResponse> DeleteWorkLocationGroup(DeleteWorkLocationGroupCommand request);
    }
}
