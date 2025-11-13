
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.OrgStructure.Commands;
using ThePatho.Features.Organization.OrgStructure.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.OrgStructure.Service
{
    public interface IOrgStructureService
    {
        Task<ApiResponse<OrgStructureItemDto>> GetOrgStructure(GetOrgStructureCommand request);
        Task<ApiResponse<OrgStructureDto>> GetSingleOrgStructure(GetSingleOrgStructureCommand request);
        Task<ApiResponse<OrgStructureItemDto>> GetOrgStructureByCriteria(GetOrgStructureByCriteriaCommand request);
        Task<ApiResponse> SubmitOrgStructure(SubmitOrgStructureCommand request);
        Task<ApiResponse> DeleteOrgStructure(DeleteOrgStructureCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportOrgStructureAsync(string type);
    }
}
