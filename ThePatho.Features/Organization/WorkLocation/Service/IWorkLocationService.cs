using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.WorkLocation.Commands;
using ThePatho.Features.Organization.WorkLocation.DTO;

namespace ThePatho.Features.Organization.WorkLocation.Service
{
    public interface IWorkLocationService
    {
        Task<ApiResponse<WorkLocationItemDto>> GetWorkLocation(GetWorkLocationCommand request);
        Task<ApiResponse<WorkLocationDto>> GetSingleWorkLocation(GetSingleWorkLocationCommand request);
        Task<ApiResponse<WorkLocationItemDto>> GetWorkLocationByCriteria(GetWorkLocationByCriteriaCommand request);
        Task<ApiResponse> SubmitWorkLocation(SubmitWorkLocationCommand request);
        Task<ApiResponse> DeleteWorkLocation(DeleteWorkLocationCommand request);
    }
}
