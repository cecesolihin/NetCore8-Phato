using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.MutationType.Commands;
using ThePatho.Features.Organization.MutationType.DTO;

namespace ThePatho.Features.Organization.MutationType.Service
{
    public interface IMutationTypeService
    {
        Task<ApiResponse<MutationTypeItemDto>> GetMutationType(GetMutationTypeCommand request);
        Task<ApiResponse<MutationTypeDto>> GetSingleMutationType(GetSingleMutationTypeCommand request);
        Task<ApiResponse<MutationTypeItemDto>> GetMutationTypeByCriteria(GetMutationTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitMutationType(SubmitMutationTypeCommand request);
        Task<ApiResponse> DeleteMutationType(DeleteMutationTypeCommand request);
    }
}
