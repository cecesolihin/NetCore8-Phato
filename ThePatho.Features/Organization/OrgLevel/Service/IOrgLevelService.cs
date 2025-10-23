
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Commands;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Service
{
    public interface IOrgLevelService
    {
        Task<ApiResponse<OrgLevelItemDto>> GetOrgLevel(GetOrgLevelCommand request);
        Task<ApiResponse<OrgLevelDto>> GetSingleOrgLevel(GetSingleOrgLevelCommand request);
        Task<ApiResponse<OrgLevelItemDto>> GetOrgLevelByCriteria(GetOrgLevelByCriteriaCommand request);
        Task<ApiResponse> SubmitOrgLevel(SubmitOrgLevelCommand request);
        Task<ApiResponse> DeleteOrgLevel(DeleteOrgLevelCommand request);
    }
}
