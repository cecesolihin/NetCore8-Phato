
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Service
{
    public interface IOrgStructureService
    {
        Task<List<OrgStructureDto>> GetOrgStructure(GetOrgStructureCommand request);
        Task<OrgStructureDto> GetOrgStructureByCriteria(GetOrgStructureByCriteriaCommand request);
        Task<bool> SubmitOrgStructure(SubmitOrgStructureCommand request);
        Task<bool> DeleteOrgStructure(DeleteOrgStructureCommand request);
    }
}
