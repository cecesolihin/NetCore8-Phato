using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.TerminationType.Commands;
using ThePatho.Features.Organization.TerminationType.DTO;
using ThePatho.Features.Common.DTO;

namespace ThePatho.Features.Organization.TerminationType.Service
{
    public interface ITerminationTypeService
    {
        Task<ApiResponse<TerminationTypeItemDto>> GetTerminationType(GetTerminationTypeCommand request);
        Task<ApiResponse<TerminationTypeDto>> GetSingleTerminationType(GetSingleTerminationTypeCommand request);
        Task<ApiResponse<TerminationTypeItemDto>> GetTerminationTypeByCriteria(GetTerminationTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitTerminationType(SubmitTerminationTypeCommand request);
        Task<ApiResponse> DeleteTerminationType(DeleteTerminationTypeCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportTerminationTypeAsync(string type);
    }
}
