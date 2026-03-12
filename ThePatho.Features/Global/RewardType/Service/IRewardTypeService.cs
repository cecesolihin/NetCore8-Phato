using ThePatho.Features.Common.DTO;
using ThePatho.Provider.ApiResponse;
using ThePatho.Features.Global.RewardType.Commands;
using ThePatho.Features.Global.RewardType.DTO;

namespace ThePatho.Features.Global.RewardType.Service
{
    public interface IRewardTypeService
    {
        Task<ApiResponse<RewardTypeItemDto>> GetRewardType(GetRewardTypeCommand request);
        Task<ApiResponse<RewardTypeDto>> GetSingleRewardType(GetSingleRewardTypeCommand request);
        Task<ApiResponse<RewardTypeItemDto>> GetRewardTypeByCriteria(GetRewardTypeByCriteriaCommand request);
        Task<ApiResponse> SubmitRewardType(SubmitRewardTypeCommand request);
        Task<ApiResponse> DeleteRewardType(DeleteRewardTypeCommand request);
        Task<ApiResponse<AttachmentFileDto>> ExportAsync(ExportRewardTypeCommand request);
    }
}

