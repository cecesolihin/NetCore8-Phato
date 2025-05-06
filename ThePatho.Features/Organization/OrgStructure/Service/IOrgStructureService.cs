
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Service
{
    public interface IOrgStructureService
    {
        Task<ApiResponse<OrgStructureItemDto>> GetOrgStructure(GetOrgStructureCommand request);
        Task<ApiResponse<OrgStructureDto>> GetOrgStructureByCriteria(GetOrgStructureByCriteriaCommand request);
        Task<ApiResponse> SubmitOrgStructure(SubmitOrgStructureCommand request);
        Task<ApiResponse> DeleteOrgStructure(DeleteOrgStructureCommand request);
    }
}
