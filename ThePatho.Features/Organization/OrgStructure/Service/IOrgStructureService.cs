
using ThePatho.Features.ConfigurationExtensions;
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Service
{
    public interface IOrgStructureService
    {
        Task<NewApiResponse<OrgStructureItemDto>> GetOrgStructure(GetOrgStructureCommand request);
        Task<NewApiResponse<OrgStructureDto>> GetOrgStructureByCriteria(GetOrgStructureByCriteriaCommand request);
        Task<ApiResponse> SubmitOrgStructure(SubmitOrgStructureCommand request);
        Task<ApiResponse> DeleteOrgStructure(DeleteOrgStructureCommand request);
    }
}
