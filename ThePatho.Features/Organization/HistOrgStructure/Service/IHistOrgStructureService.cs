using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.HistOrgStructure.Commands;
using ThePatho.Features.Organization.HistOrgStructure.DTO;

namespace ThePatho.Features.Organization.HistOrgStructure.Service
{
    public interface IHistOrgStructureService
    {
        Task<ApiResponse<HistOrgStructureItemDto>> GetHistOrgStructure(GetHistOrgStructureCommand request);
        Task<ApiResponse<HistOrgStructureDto>> GetSingleHistOrgStructure(GetSingleHistOrgStructureCommand request);
        Task<ApiResponse<HistOrgStructureItemDto>> GetHistOrgStructureByCriteria(GetHistOrgStructureByCriteriaCommand request);
        Task<ApiResponse> SubmitHistOrgStructure(SubmitHistOrgStructureCommand request);
        Task<ApiResponse> DeleteHistOrgStructure(DeleteHistOrgStructureCommand request);
    }
}
