
using ThePatho.Features.Organization.OrgLevel.Commands;
using ThePatho.Features.Organization.OrgLevel.DTO;

namespace ThePatho.Features.Organization.OrgLevel.Service
{
    public interface IOrgLevelService
    {
        Task<List<OrgLevelDto>> GetOrganizationLevel(GetOrgLevelCommand request);
        Task<OrgLevelDto> GetOrganizationLevelByCriteria(GetOrgLevelByCriteriaCommand request);
        Task<bool> SubmitOrganizationLevel(SubmitOrgLevelCommand request);
        Task<bool> DeleteOrganizationLevel(DeleteOrgLevelCommand request);
    }
}
