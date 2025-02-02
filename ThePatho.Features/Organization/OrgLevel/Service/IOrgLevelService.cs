
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgLevel.Commands;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Service
{
    public interface IOrgLevelService
    {
        Task<NewApiResponse<OrgLevelItemDto>> GetOrganizationLevel(GetOrgLevelCommand request);
        Task<NewApiResponse<OrgLevelDto>> GetOrganizationLevelByCriteria(GetOrgLevelByCriteriaCommand request);
        Task<ApiResponse> SubmitOrganizationLevel(SubmitOrgLevelCommand request);
        Task<ApiResponse> DeleteOrganizationLevel(DeleteOrgLevelCommand request);
    }
}
