using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Organization.PensionType.Commands;
using ThePatho.Features.Organization.PensionType.DTO;

namespace ThePatho.Features.Organization.PensionType.Service
{
    public interface IPensionTypeService
    {
        Task<ApiResponse<PensionTypeItemDto>> GetPensionType(GetPensionTypeCommand request);
        Task<ApiResponse<PensionTypeDto>> GetSinglePensionType(GetSinglePensionTypeCommand request);
        Task<ApiResponse<PensionTypeItemDto>> GetPensionTypeByCriteria(GetPensionTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitPensionType(SubmitPensionTypeCommand request);
        Task<ApiResponse> DeletePensionType(DeletePensionTypeCommand request);
    }
}
