
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgLevel.Commands;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Service
{
    public interface IOrgLevelService
    {
        Task<ApiResponse<OrgLevelItemDto>> GetOrganizationLevel(GetOrgLevelCommand request);
        Task<ApiResponse<OrgLevelDto>> GetOrganizationLevelByCriteria(GetOrgLevelByCriteriaCommand request);
        Task<ApiResponse> SubmitOrganizationLevel(SubmitOrgLevelCommand request);
        Task<ApiResponse> DeleteOrganizationLevel(DeleteOrgLevelCommand request);
    }
}
